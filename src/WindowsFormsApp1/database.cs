class FingerprintDB{
    private MySqlConnection connection;
    private string server;
    private string database;
    private string uid;
    private string password;


    myConnectionString = "server=localhost:3306;uid=root;" +
        "pwd=12345;database=tubes3";

    public DBConnect()
    {
        Initialize();
    }

    private void Initialize()
    {
        server = "localhost:3306";
        database = "tubes3";
        uid = "root";
        password = "isPain";
        string connectionString;
        connectionString = "SERVER=" + server + ";" + "DATABASE=" + 
		database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

        connection = new MySqlConnection(connectionString);
    }

    private bool OpenConnection(){
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

    private bool CloseConnection()
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