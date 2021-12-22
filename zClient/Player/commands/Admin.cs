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

            }
        }

    }
}
