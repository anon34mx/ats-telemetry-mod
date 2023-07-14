using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Funbit.Ets.Telemetry.Server
{
    internal class MySql_conn
    {
       public static MySqlConnection connMaster;

        public static MySqlConnection dataSource()
        {
            //myConnectionString = "server=127.0.0.1;uid=root;" +
            //    "pwd=12345;database=test";
            string DB_server = Properties.Settings.Default.DB_server;
            string DB_name = Properties.Settings.Default.DB_name;
            string DB_user = Properties.Settings.Default.DB_user;
            string DB_pass = Properties.Settings.Default.DB_pass;
            try
            {
                return connMaster = new MySql.Data.MySqlClient.MySqlConnection($"server={DB_server}; database={DB_name}; Uid={DB_user}; password={DB_pass};");
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                return null;
            }
        }

        public void connOpen()
        {
            dataSource();
            connMaster.Open();
        }
        public void connClose()
        {
            dataSource();
            connMaster.Close();
        }
        public MySqlConnection get()
        {
            return connMaster;
        }
    }
}
