using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Funbit.Ets.Telemetry.Server
{
    public partial class DBConfig : Form
    {
        MainForm mainForm;
        public DBConfig(MainForm MF)
        {
            InitializeComponent();
            text_server.Text = Properties.Settings.Default["DB_server"].ToString();
            text_name.Text = Properties.Settings.Default["DB_name"].ToString();
            text_port.Text = Properties.Settings.Default["DB_port"].ToString();
            text_user.Text = Properties.Settings.Default["DB_user"].ToString();
            text_password.Text = Properties.Settings.Default["DB_pass"].ToString();

            mainForm = MF;
        }

        private void check_db_type_CheckedChanged(object sender, EventArgs e)
        {
            //check_db_type
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.DB_server = text_server.Text;
            Properties.Settings.Default.DB_name = text_name.Text;
            Properties.Settings.Default.DB_port = text_port.Text;
            Properties.Settings.Default.DB_user = text_user.Text;
            Properties.Settings.Default.DB_pass = text_password.Text;
            Properties.Settings.Default.Save(); // Saves settings in application configuration file

            System.Windows.Forms.MessageBox.Show("Saved");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mainForm.connectToDb();
        }
    }
}
