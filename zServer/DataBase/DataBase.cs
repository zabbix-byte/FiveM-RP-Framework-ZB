using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using MySql.Data.MySqlClient;

using CitizenFX.Core.Native;

namespace zServer
{
    class DataBase
    {
        IniFile config = new IniFile("ZombiLand", "config.ini");
        private MySqlConnection connection;
        private string server;
        private string database;
        private string user;
        private string password;

        // constructor
        public DataBase() { Initialize(); }

        private void Initialize()
        {
            server = config.GetStringValue("database_config", "server", "fallback");
            database = config.GetStringValue("database_config", "database", "fallback");
            user = config.GetStringValue("database_config", "user", "fallback");
            password = config.GetStringValue("database_config", "password", "fallback");
            string connectionString = $"datasource={server};port=3306;username={user};password={password};database={database};";
            connection = new MySqlConnection(connectionString);
        }

        //open connection to database
        private string OpenConnection()
        {
            try
            {
                connection.Open();
                return "ok";
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        return "Cannot connect to server.  Contact administrator";

                    case 1045:
                        return "Invalid username/password, please try again";
                }
                return ex.Message;
            }
        }

        //Close connection
        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void insert(string query)
        {
            if (this.OpenConnection() == "ok")
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                this.CloseConnection();
            }
        }
        public Dictionary<int, string[]> directQuery(string query)
        {
            Dictionary<int, string[]> data = new Dictionary<int, string[]>();

            if (this.OpenConnection() == "ok")
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                if (dataReader.HasRows)
                {
                    int key_data = 0;
                    while (dataReader.Read())
                    {
                        string[] q_values = new String[dataReader.FieldCount];
                        for (int i = 0; i < dataReader.FieldCount; i++)
                        {
                            q_values.SetValue(dataReader.GetValue(i).ToString(), i);
                        }
                        data.Add(key_data, q_values);
                        key_data++;
                    }
                }
                else { string[] error = { "Conexion error" }; data.Add(0, error); this.CloseConnection(); ; return data; }
                this.CloseConnection();
                return data;

            }
            else { string[] error = { "Conexion error" }; data.Add(0, error); this.CloseConnection(); ; return data; }
        }

        public void update(string query)
        {
            if (this.OpenConnection() == "ok")
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = query;
                cmd.Connection = connection;
                cmd.ExecuteNonQuery();
                this.CloseConnection();
            }
        }

    }
}
