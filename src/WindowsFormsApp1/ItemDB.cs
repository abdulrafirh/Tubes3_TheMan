using Bogus.DataSets;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public class ItemDB
    {
        protected static MySqlConnection connection;
        protected static bool hasBeenInitialized = false;

        protected static void Initialize()
        {
            string server = "localhost";
            string database = "tubes3";
            string uid = "root";
            string password = "pwdbaldy";
            string port = "3306";
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
