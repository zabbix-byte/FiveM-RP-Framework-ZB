using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

// fivem imports
using CitizenFX.Core;
using static CitizenFX.Core.Native.API;


namespace zServer
{
    internal class Auth : BaseScript
    {
        IniFile config = new IniFile("ZombiLand", "config.ini");
        DataBase database_conection = new DataBase();

        public Auth()
        {
            Console.WriteLine($"    ===========================================\n"); 
            Console.WriteLine($"        Welcome to ZombiLand Framework.");
            Console.WriteLine($"    _");

            Dictionary<int, string[]> data_test =  database_conection.directQuery("SELECT version()");
            if (data_test[0][0] =="Conexion error")
            {
                Console.WriteLine($"        DataBase conexion error \n        Check the config.ini \n ");

            }
            else
            {
                Console.WriteLine($"        DataBase conexion successful \n        DataBase Version: {data_test[0][0]} \n ");
            }

            Console.WriteLine($"    ===========================================\n");


            EventHandlers["login"] += new Action<string, string, int>(login);
            EventHandlers["register"] += new Action<Player, string, string, string>(register);
            EventHandlers["logout"] += new Action<string>(logout);

            EventHandlers["playerDropped"] += new Action<Player, string>(OnPlayerDropped);
            EventHandlers["playerConnecting"] += new Action<Player, string>(playerConnecting);
        }


        private void login(string username, string password, int temporal_id)
        {
            Dictionary<int, string[]> data = database_conection.directQuery(
                $"SELECT password, email, `group`  FROM users WHERE username = '{username}';");

            PlayerList player = new PlayerList();
            Player user = player[temporal_id];

            if (password == data[0][0])
            {   
                string temporal_id_q = $"UPDATE users SET temporal_id = '{temporal_id}' WHERE username = '{username}'";
                database_conection.update(temporal_id_q);
                TriggerClientEvent(user, "login", username, data[0][1], data[0][2], temporal_id);
                TriggerClientEvent(user, "sendOnUserChat", $"Welcome {username} have fun!");
            }
            else { TriggerClientEvent(user, "sendOnUserChat", $"The user or password is wrong");}
        }


        private void register([FromSource] Player user, string username, string email, string password)
        {
            string query = $"INSERT INTO `users` (`username`, `email`, `group`, `password`) VALUES ('{username}', '{email}', 'user', '{password}')";
            database_conection.insert(query);   
        }

        private void logout(string username)
        {
            Dictionary<int, string[]> id = database_conection.directQuery(
                $"SELECT temporal_id  FROM users WHERE username = '{username}';");

            string temporal_id_q = $"UPDATE users SET temporal_id = '0' WHERE username = '{username}'";
            database_conection.update(temporal_id_q);

            DropPlayer(id[0][0], $"[ {config.GetStringValue("server_info", "server_name", "fallback")} ] You've disconnected. We wait for you back!");
        }


        private void OnPlayerDropped([FromSource] Player user, string reason)
        {
            int playerId = int.Parse(user.Handle);
            string temporal_id_q = $"UPDATE users SET temporal_id = '0' WHERE temporal_id = '{playerId}'";
            database_conection.update(temporal_id_q);
        }

        private void playerConnecting([FromSource] Player user, string reason)
        {
        }
    }
}
