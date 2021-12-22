using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// fivem imports
using CitizenFX.Core;
using static CitizenFX.Core.Native.API;

namespace zServer 
{
    internal class Admin : BaseScript
    {
        DataBase database_conection = new DataBase();
        public Admin() 
        {
            EventHandlers["getUserInfo"] += new Action<Player, string>(getUserInfo);
        }

        private void getUserInfo([FromSource] Player user, string id)
        {
            Dictionary<int, string[]> data = database_conection.directQuery(
                $"SELECT username, email, `group`, temporal_id  FROM users WHERE temporal_id = '{id}';");
            TriggerClientEvent(user, "sendOnUserChat", $"Username: {data[0][0]} Email: {data[0][1]} Group: {data[0][2]} Id: {data[0][3]}");

        }

    }
}
