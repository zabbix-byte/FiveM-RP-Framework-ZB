using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// fivem imports
using CitizenFX.Core;
using static CitizenFX.Core.Native.API;

namespace zClient
{
    internal class Admin : Auth
    {
        ChatMessage chatmes = new ChatMessage();

        public Admin() { EventHandlers["onLogin"] += new Action(onLogin); }

        private void onLogin()
        {
            if (this.group == "admin")
            {
                RegisterCommand("id", new Action<int, List<object>, string>((source, args, raw) => {
                    TriggerServerEvent("getUserInfo",  args[0]);
                }), false);

                RegisterCommand("coords", new Action<int, List<object>, string>((source, args, raw) => {
                     chatmes.send(GetEntityCoords(PlayerPedId(), false).ToString());
                }), false);

                RegisterCommand("tpa", new Action<int, List<object>, string>((source, args, raw) => {
                    int player_id = Int32.Parse(args[0].ToString());
                    Vector3 player_coords = GetEntityCoords(NetworkGetEntityFromNetworkId(player_id), false);
                    SetEntityCoords(PlayerPedId(), player_coords.X, player_coords.Y, player_coords.Z, false, false, false, false);
                }), false);

            }
        }

    }
}
