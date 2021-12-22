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
    public class Auth : BaseScript
    {
        ChatMessage chatmes = new ChatMessage();
        public string username { get; set; }
        public string email { get; set; }
        public string group { get; set; }
        public int temporal_id { get; set; }

        public Auth(){

            checkLogin();

            EventHandlers["onClientResourceStart"] += new Action<string>(OnClientResourceStart);
            EventHandlers["login"] += new Action<string, string, string, int>(login);

        }

        private void OnClientResourceStart(string resourceName)
        {
            if (GetCurrentResourceName() != resourceName) return;
            RegisterCommand("login", new Action<int, List<object>, string>((source, args, raw) =>
            {
             TriggerServerEvent("login", args[0].ToString(), args[1].ToString(), GetPlayerServerId(PlayerId())); 
            }), false);

            RegisterCommand("register", new Action<int, List<object>, string>((source, args, raw) =>
            {
                TriggerServerEvent("register", args[0].ToString(), args[1].ToString(), args[2].ToString());

            }), false);
        }

        private void login(string username, string email, string group, int temporal_id) 
        {
            this.username = username;
            this.email = email;
            this.group = group;
            this.temporal_id = temporal_id;
            TriggerEvent("onLogin");
        }

        private async void checkLogin()
        {
            while (true)
            {
                await Delay(0);
                if (temporal_id > 0)
                {
                    FreezeEntityPosition(PlayerPedId(), false);
                    break;
                }
                else
                {
                    FreezeEntityPosition(PlayerPedId(), true);
                }

            }


        }

    }
}
