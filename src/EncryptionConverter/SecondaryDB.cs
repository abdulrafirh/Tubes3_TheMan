using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace EncryptionConverter
{
    public class SecondaryDB
    {
        protected static MySqlConnection connection;
        protected static bool hasBeenInitialized = false;
        public static void Initialize() {
            string server = "localhost";
            string database = "tubes3dump";
            string uid = "root";
            string password = "thefunni";
            string port = "12345";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "PORT=" + port + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);
            hasBeenInitialized = true;
        }
        protected static bool OpenConnection()
        {

            if (!hasBeenInitialized)
            {
                Initialize();
            }

            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                // 0: Cannot connect to server.
                // 1045: Invalid user name and/or password.
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        MessageBox.Show("Invalid username/password, please try again");
                        break;
                }
                return false;
            }
        }
        protected static bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
    }
}
