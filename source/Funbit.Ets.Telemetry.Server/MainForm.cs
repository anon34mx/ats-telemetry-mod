using System;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using Funbit.Ets.Telemetry.Server.Controllers;
using Funbit.Ets.Telemetry.Server.Data;
using Funbit.Ets.Telemetry.Server.Helpers;
using Funbit.Ets.Telemetry.Server.Setup;
using Microsoft.Owin.Hosting;
using Newtonsoft.Json;
using MySql.Data.MySqlClient;
using System.Globalization;
using System.Threading.Tasks;

namespace Funbit.Ets.Telemetry.Server
{
    public partial class MainForm : Form
    {
        IDisposable _server;
        static readonly log4net.ILog Log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        readonly HttpClient _broadcastHttpClient = new HttpClient();
        static readonly Encoding Utf8 = new UTF8Encoding(false);
        static readonly string BroadcastUrl = ConfigurationManager.AppSettings["BroadcastUrl"];
        static readonly string BroadcastUserId = Convert.ToBase64String(
            Utf8.GetBytes(ConfigurationManager.AppSettings["BroadcastUserId"] ?? ""));
        static readonly string BroadcastUserPassword = Convert.ToBase64String(
            Utf8.GetBytes(ConfigurationManager.AppSettings["BroadcastUserPassword"] ?? ""));
        static readonly int BroadcastRateInSeconds = Math.Min(Math.Max(1, 
            Convert.ToInt32(ConfigurationManager.AppSettings["BroadcastRate"])), 86400);
        static readonly bool UseTestTelemetryData = Convert.ToBoolean(
            ConfigurationManager.AppSettings["UseEts2TestTelemetryData"]);
        private MySqlConnection mysqlConn;

        public MainForm()
        {
            InitializeComponent();
        }

        static string IpToEndpointUrl(string host)
        {
            return $"http://{host}:{ConfigurationManager.AppSettings["Port"]}";
        }

        void Setup()
        {
            try
            {
                if (Program.UninstallMode && SetupManager.Steps.All(s => s.Status == SetupStatus.Uninstalled))
                {
                    MessageBox.Show(this, @"Server is not installed, nothing to uninstall.", @"Done",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Environment.Exit(0);
                }

                if (Program.UninstallMode || SetupManager.Steps.Any(s => s.Status != SetupStatus.Installed))
                {
                    // we wait here until setup is complete
                    var result = new SetupForm().ShowDialog(this);
                    if (result == DialogResult.Abort)
                        Environment.Exit(0);
                }

                // raise priority to make server more responsive (it does not eat CPU though!)
                Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.AboveNormal;
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                ex.ShowAsMessageBox(this, @"Setup error");
            }
        }

        void Start()
        {
            try
            {
                // load list of available network interfaces
                var networkInterfaces = NetworkHelper.GetAllActiveNetworkInterfaces();
                interfacesDropDown.Items.Clear();
                foreach (var networkInterface in networkInterfaces)
                    interfacesDropDown.Items.Add(networkInterface);
                // select remembered interface or default
                var rememberedInterface = networkInterfaces.FirstOrDefault(
                    i => i.Id == Settings.Instance.DefaultNetworkInterfaceId);
                if (rememberedInterface != null)
                    interfacesDropDown.SelectedItem = rememberedInterface;
                else
                    interfacesDropDown.SelectedIndex = 0; // select default interface

                // bind to all available interfaces
                _server = WebApp.Start<Startup>(IpToEndpointUrl("+"));

                // start ETS2 process watchdog timer
                statusUpdateTimer.Enabled = true;

                // turn on broadcasting if set
                if (!string.IsNullOrEmpty(BroadcastUrl))
                {
                    _broadcastHttpClient.DefaultRequestHeaders.Add("X-UserId", BroadcastUserId);
                    _broadcastHttpClient.DefaultRequestHeaders.Add("X-UserPassword", BroadcastUserPassword);
                    broadcastTimer.Interval = BroadcastRateInSeconds * 1000;
                    broadcastTimer.Enabled = true;
                }

                // show tray icon
                trayIcon.Visible = true;
                
                // make sure that form is visible
                Activate();
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                ex.ShowAsMessageBox(this, @"Network error", MessageBoxIcon.Exclamation);
            }

            
            //mysqlConn = new MySql_conn();
            //mysqlConn.connOpen();
            string DB_server = Properties.Settings.Default.DB_server;
            string DB_name = Properties.Settings.Default.DB_name;
            string DB_user = Properties.Settings.Default.DB_user;
            string DB_pass = Properties.Settings.Default.DB_pass;
            try
            {
                mysqlConn = new MySql.Data.MySqlClient.MySqlConnection($"server={DB_server}; database={DB_name}; Uid={DB_user}; password={DB_pass};");
                Console.WriteLine(mysqlConn.State);
                mysqlConn.Open();
                mysqlConn.Close();
                lbl_db_status.Text = "Connected";
                lbl_db_status.ForeColor = System.Drawing.Color.Green;

                Console.WriteLine("conectado a BD");
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                Console.WriteLine(ex);
                lbl_db_status.Text = "Not connected :c";
                lbl_db_status.ForeColor = System.Drawing.Color.Red;
                check_saveToDb.Checked = false;
            }

        }
        
        void MainForm_Load(object sender, EventArgs e)
        {
            // log current version for debugging
            Log.InfoFormat("Running application on {0} ({1}) {2}", Environment.OSVersion, 
                Environment.Is64BitOperatingSystem ? "64-bit" : "32-bit",
                Program.UninstallMode ? "[UNINSTALL MODE]" : "");
            Text += @" " + AssemblyHelper.Version;

            // install or uninstall server if needed
            Setup();

            // start WebApi server
            Start();
            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Interval = 1000;
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
        }

        void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            _server?.Dispose();
            trayIcon.Visible = false;
        }
    
        void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        void trayIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            WindowState = FormWindowState.Normal;
        }

        void statusUpdateTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                if (UseTestTelemetryData)
                {
                    statusLabel.Text = @"Connected to Ets2TestTelemetry.json";
                    statusLabel.ForeColor = Color.DarkGreen;
                } 
                else if (Ets2ProcessHelper.IsEts2Running && Ets2TelemetryDataReader.Instance.IsConnected)
                {
                    statusLabel.Text = $"Connected to the simulator ({Ets2ProcessHelper.LastRunningGameName})";
                    statusLabel.ForeColor = Color.DarkGreen;
                }
                else if (Ets2ProcessHelper.IsEts2Running)
                {
                    statusLabel.Text = $"Simulator is running ({Ets2ProcessHelper.LastRunningGameName})";
                    statusLabel.ForeColor = Color.Teal;
                }
                else
                {
                    statusLabel.Text = @"Simulator is not running";
                    statusLabel.ForeColor = Color.FromArgb(240, 55, 30);
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                ex.ShowAsMessageBox(this, @"Process error");
                statusUpdateTimer.Enabled = false;
            }
        }

        void apiUrlLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ProcessHelper.OpenUrl(((LinkLabel)sender).Text);
        }

        void appUrlLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ProcessHelper.OpenUrl(((LinkLabel)sender).Text);
        }
        
        void MainForm_Resize(object sender, EventArgs e)
        {
            ShowInTaskbar = WindowState != FormWindowState.Minimized;
            if (!ShowInTaskbar && trayIcon.Tag == null)
            {
                trayIcon.ShowBalloonTip(1000, @"ETS2/ATS Telemetry Server", @"Double-click to restore.", ToolTipIcon.Info);
                trayIcon.Tag = "Already shown";
            }
        }

        void interfaceDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedInterface = (NetworkInterfaceInfo) interfacesDropDown.SelectedItem;
            appUrlLabel.Text = IpToEndpointUrl(selectedInterface.Ip) + Ets2AppController.TelemetryAppUriPath;
            apiUrlLabel.Text = IpToEndpointUrl(selectedInterface.Ip) + Ets2TelemetryController.TelemetryApiUriPath;
            ipAddressLabel.Text = selectedInterface.Ip;
            Settings.Instance.DefaultNetworkInterfaceId = selectedInterface.Id;
            Settings.Instance.Save();
        }

        async void broadcastTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                broadcastTimer.Enabled = false;
                await _broadcastHttpClient.PostAsJsonAsync(BroadcastUrl, Ets2TelemetryDataReader.Instance.Read());
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }
            broadcastTimer.Enabled = true;
        }
        
        void uninstallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string exeFileName = Process.GetCurrentProcess().MainModule.FileName;
            var startInfo = new ProcessStartInfo
            {
                Arguments = $"/C ping 127.0.0.1 -n 2 && \"{exeFileName}\" -uninstall",
                WindowStyle = ProcessWindowStyle.Hidden,
                CreateNoWindow = true,
                FileName = "cmd.exe"
            };
            Process.Start(startInfo);
            Application.Exit();
        }

        void donateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProcessHelper.OpenUrl("http://funbit.info/ets2/donate.htm");
        }

        void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProcessHelper.OpenUrl("https://github.com/Funbit/ets2-telemetry-server");
        }

        void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // TODO: implement later
        }
        int timerCount = 0;
        void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (Ets2ProcessHelper.IsEts2Running && Ets2TelemetryDataReader.Instance.IsConnected)
            {
                var data = Ets2TelemetryDataReader.Instance.Read();
                if (data.Game.Connected == true && data.Game.Paused == false && check_saveToDb.Checked==true && lbl_db_status.Text == "Connected")
                {
                    Console.WriteLine(timerCount + " ");
                    timerCount++;
                    try
                    {
                        var str_insrt = $"INSERT INTO raw" +
                        $"(" +
                        $"driver_id," +
                        $"game_time," +
                        $"game_timescale," +
                        $"game_nextreststoptime," +
                        $"truck_id," +
                        $"truck_make," +
                        $"truck_model," +
                        $"truck_speed," +
                        $"truck_cruisecontrolspeed," +
                        $"truck_cruisecontrolon," +
                        $"truck_odometer," +
                        $"truck_gear," +
                        $"truck_displayedGear," +
                        $"truck_engineRpm," +
                        $"truck_fuel," +
                        $"truck_fuelCapacity," +
                        $"truck_fuelAverageConsumption," +
                        $"truck_fuelWarningOn," +
                        $"truck_wearEngine," +
                        $"truck_wearTransmission," +
                        $"truck_wearCabin," +
                        $"truck_wearChassis," +
                        $"truck_wearWheels," +
                        $"truck_userSteer," +
                        $"truck_userThrottle," +
                        $"truck_userBrake," +
                        $"truck_userClutch," +
                        $"truck_gameSteer," +
                        $"truck_gameThrottle," +
                        $"truck_gameBrake," +
                        $"truck_gameClutch," +
                        $"truck_shifterSlot," +
                        $"truck_engineOn," +
                        $"truck_electricOn," +
                        $"truck_wipersOn," +
                        $"truck_retarderBrake," +
                        $"truck_retarderStepCount," +
                        $"truck_parkBrakeOn," +
                        $"truck_motorBrakeOn," +
                        $"truck_brakeTemperature," +
                        $"truck_adblue," +
                        $"truck_adblueCapacity," +
                        $"truck_adblueAverageConsumption," +
                        $"truck_adblueWarningOn," +
                        $"truck_airPressure," +
                        $"truck_airPressureWarningOn," +
                        $"truck_airPressureWarningValue," +
                        $"truck_airPressureEmergencyOn," +
                        $"truck_airPressureEmergencyValue," +
                        $"truck_oilTemperature," +
                        $"truck_oilPressure," +
                        $"truck_oilPressureWarningOn," +
                        $"truck_oilPressureWarningValue," +
                        $"truck_waterTemperature," +
                        $"truck_waterTemperatureWarningOn," +
                        $"truck_waterTemperatureWarningValue," +
                        $"truck_batteryVoltage," +
                        $"truck_batteryVoltageWarningOn," +
                        $"truck_batteryVoltageWarningValue," +
                        $"truck_lightsDashboardValue," +
                        $"truck_lightsDashboardOn," +
                        $"truck_blinkerLeftActive," +
                        $"truck_blinkerRightActive," +
                        $"truck_blinkerLeftOn," +
                        $"truck_blinkerRightOn," +
                        $"truck_lightsParkingOn," +
                        $"truck_lightsBeamLowOn," +
                        $"truck_lightsBeamHighOn," +
                        $"truck_lightsAuxFrontOn," +
                        $"truck_lightsAuxRoofOn," +
                        $"truck_lightsBeaconOn," +
                        $"truck_lightsBrakeOn," +
                        $"truck_lightsReverseOn," +
                        $"truck_placement_x," +
                        $"truck_placement_y," +
                        $"truck_placement_z," +
                        $"truck_placement_heading," +
                        $"truck_placement_pitch," +
                        $"truck_placement_roll," +
                        $"truck_acceleration_x," +
                        $"truck_acceleration_y," +
                        $"truck_acceleration_z," +
                        $"truck_head_x," +
                        $"truck_head_y," +
                        $"truck_head_z," +
                        $"truck_cabin_x," +
                        $"truck_cabin_y," +
                        $"truck_cabin_z," +
                        $"truck_hook_x," +
                        $"truck_hook_y," +
                        $"truck_hook_z," +
                        $"trailer_attached," +
                        $"trailer_id," +
                        $"trailer_name," +
                        $"trailer_mass," +
                        $"trailer_wear," +
                        $"trailer_placement_x," +
                        $"trailer_placement_y," +
                        $"trailer_placement_z," +
                        $"trailer_placement_heading," +
                        $"trailer_placement_pitch," +
                        $"trailer_placement_roll," +
                        $"job_income," +
                        $"job_deadlineTime," +
                        $"job_remainingTime," +
                        $"job_sourceCity," +
                        $"job_sourceCompany," +
                        $"job_destinationCity," +
                        $"job_destinationCompany," +
                        $"estimatedTime," +
                        $"estimatedDistance," +
                        $"speedLimit" +
                        $") VALUES (" +

                        $"\"{txt_DriverId.Text}\"," +
                        $"\"{data.Game.Time.ToString("yyyy-MM-dd H:mm:ss")}\"," +
                        $"{data.Game.TimeScale}," +
                        $"\"{data.Game.NextRestStopTime.ToString("yyyy-MM-dd H:mm:ss")}\"," +
                        $"\"{data.Truck.Id}\"," +
                        $"\"{data.Truck.Make}\"," +
                        $"\"{data.Truck.Model}\"," +
                        $"{Math.Round(data.Truck.Speed), 2}," +
                        $"{Math.Round(data.Truck.CruiseControlSpeed), 2}," +
                        $"{data.Truck.CruiseControlOn}," +
                        $"{Math.Round(data.Truck.Odometer,3)}," +
                        $"{data.Truck.Gear}," +
                        $"{data.Truck.DisplayedGear}," +
                        $"{Math.Round(data.Truck.EngineRpm,2)}," +
                        $"{Math.Round(data.Truck.Fuel,2)}," +
                        $"{Math.Round(data.Truck.FuelCapacity,2)}," +
                        $"{Math.Round(data.Truck.FuelAverageConsumption, 2)}," +
                        $"{data.Truck.FuelWarningOn}," +
                        $"{Math.Round(data.Truck.WearEngine,5)}," +
                        $"{Math.Round(data.Truck.WearTransmission,5)}," +
                        $"{Math.Round(data.Truck.WearCabin,5)}," +
                        $"{Math.Round(data.Truck.WearChassis,5)}," +
                        $"{Math.Round(data.Truck.WearWheels,5)}," +
                        $"{Math.Round(data.Truck.UserSteer,2)}," +
                        $"{Math.Round(data.Truck.UserThrottle,2)}," +
                        $"{Math.Round(data.Truck.UserBrake,2)}," +
                        $"{Math.Round(data.Truck.UserClutch,2)}," +
                        $"{Math.Round(data.Truck.GameSteer,2)}," +
                        $"{Math.Round(data.Truck.GameThrottle,4)}," +
                        $"{Math.Round(data.Truck.GameBrake,2)}," +
                        $"{Math.Round(data.Truck.GameClutch, 2)}," +
                        $"{data.Truck.ShifterSlot}," +
                        $"{data.Truck.EngineOn}," +
                        $"{data.Truck.ElectricOn}," +
                        $"{data.Truck.WipersOn}," +
                        $"{data.Truck.RetarderBrake}," +
                        $"{data.Truck.RetarderStepCount}," +
                        $"{data.Truck.ParkBrakeOn}," +
                        $"{data.Truck.MotorBrakeOn}," +
                        $"{Math.Round(data.Truck.BrakeTemperature,2)}," +
                        $"{Math.Round(data.Truck.Adblue,2)}," +
                        $"{Math.Round(data.Truck.AdblueCapacity,2)}," +
                        $"{Math.Round(data.Truck.AdblueAverageConsumption, 2)}," +
                        $"{data.Truck.AdblueWarningOn}," +
                        $"{Math.Round(data.Truck.AirPressure, 2)}," +
                        $"{data.Truck.AirPressureWarningOn}," +
                        $"{Math.Round(data.Truck.AirPressureWarningValue, 2)}," +
                        $"{data.Truck.AirPressureEmergencyOn}," +
                        $"{Math.Round(data.Truck.AirPressureEmergencyValue,2)}," +
                        $"{Math.Round(data.Truck.OilTemperature,2)}," +
                        $"{Math.Round(data.Truck.OilPressure, 2)}," +
                        $"{data.Truck.OilPressureWarningOn}," +
                        $"{Math.Round(data.Truck.OilPressureWarningValue, 2)}," +
                        $"{Math.Round(data.Truck.WaterTemperature, 2)}," +
                        $"{data.Truck.WaterTemperatureWarningOn}," +
                        $"{Math.Round(data.Truck.WaterTemperatureWarningValue,2)}," +
                        $"{Math.Round(data.Truck.BatteryVoltage, 2)}," +
                        $"{data.Truck.BatteryVoltageWarningOn}," +
                        $"{Math.Round(data.Truck.BatteryVoltageWarningValue,2)}," +
                        $"{Math.Round(data.Truck.LightsDashboardValue, 2)}," +
                        $"{data.Truck.LightsDashboardOn}," +
                        $"{data.Truck.BlinkerLeftActive}," +
                        $"{data.Truck.BlinkerRightActive}," +
                        $"{data.Truck.BlinkerLeftOn}," +
                        $"{data.Truck.BlinkerRightOn}," +
                        $"{data.Truck.LightsParkingOn}," +
                        $"{data.Truck.LightsBeamLowOn}," +
                        $"{data.Truck.LightsBeamHighOn}," +
                        $"{data.Truck.LightsAuxFrontOn}," +
                        $"{data.Truck.LightsAuxRoofOn}," +
                        $"{data.Truck.LightsBeaconOn}," +
                        $"{data.Truck.LightsBrakeOn}," +
                        $"{data.Truck.LightsReverseOn}," +
                        $"{Math.Round(data.Truck.Placement.X,4)}," +
                        $"{Math.Round(data.Truck.Placement.Y,4)}," +
                        $"{Math.Round(data.Truck.Placement.Z,4)}," +
                        $"{Math.Round(data.Truck.Placement.Heading,4)}," +
                        $"{Math.Round(data.Truck.Placement.Pitch,4)}," +
                        $"{Math.Round(data.Truck.Placement.Roll,4)}," +
                        $"{Math.Round(data.Truck.Acceleration.X,6)}," +
                        $"{Math.Round(data.Truck.Acceleration.Y,6)}," +
                        $"{Math.Round(data.Truck.Acceleration.Z,6)}," +
                        $"{Math.Round(data.Truck.Head.X,6)}," +
                        $"{Math.Round(data.Truck.Head.Y,6)}," +
                        $"{Math.Round(data.Truck.Head.Z,6)}," +
                        $"{Math.Round(data.Truck.Cabin.X,2)}," +
                        $"{Math.Round(data.Truck.Cabin.Y,2)}," +
                        $"{Math.Round(data.Truck.Cabin.Z,2)}," +
                        $"{Math.Round(data.Truck.Hook.X,6)}," +
                        $"{Math.Round(data.Truck.Hook.Y,6)}," +
                        $"{Math.Round(data.Truck.Hook.Z, 6)}," +
                        $"{data.Trailer.Attached}," +
                        $"\"{data.Trailer.Id}\"," +
                        $"\"{data.Trailer.Name}\"," +
                        $"{Math.Round(data.Trailer.Mass,2)}," +
                        $"{Math.Round(data.Trailer.Wear,9)}," +
                        $"{Math.Round(data.Trailer.Placement.X,6)}," +
                        $"{Math.Round(data.Trailer.Placement.Y,6)}," +
                        $"{Math.Round(data.Trailer.Placement.Z,6)}," +
                        $"{Math.Round(data.Trailer.Placement.Heading,6)}," +
                        $"{Math.Round(data.Trailer.Placement.Pitch,6)}," +
                        $"{Math.Round(data.Trailer.Placement.Roll, 6)}," +
                        $"{Math.Round((float)data.Job.Income, 2)}," +
                        $"\"{data.Job.DeadlineTime}\"," +
                        $"\"{data.Job.RemainingTime}\"," +
                        $"\"{data.Job.SourceCity}\"," +
                        $"\"{data.Job.SourceCompany}\"," +
                        $"\"{data.Job.DestinationCity}\"," +
                        $"\"{data.Job.DestinationCompany}\"," +
                        $"\"{data.Navigation.EstimatedTime}\"," +
                        $"{data.Navigation.EstimatedDistance}," +
                        $"{data.Navigation.SpeedLimit}" +
                        $");";
                        Console.WriteLine(str_insrt);
                        MySqlCommand insrt = new MySqlCommand(str_insrt, mysqlConn);
                        MySqlDataReader rs;
                        mysqlConn.Open();
                        rs = insrt.ExecuteReader();
                        mysqlConn.Close();
                    }
                    catch (MySqlException ex)
                    {
                        Console.WriteLine(ex);
                        lbl_db_status.Text = "Error";
                        lbl_db_status.ForeColor= System.Drawing.Color.Red;
                    }
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
