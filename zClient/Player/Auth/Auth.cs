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
        NUI gamenui = new NUI();
        IniFile config = new IniFile("ZombiLand", "config.ini");
        ChatMessage chatmes = new ChatMessage();
        public string username { get; set; }
        public string email { get; set; }
        public string group { get; set; }
        public int temporal_id { get; set; }

        public Auth()
        {   
            EventHandlers["onClientResourceStart"] += new Action<string>(OnClientResourceStart);
            EventHandlers["login"] += new Action<string, string, string, int>(login);
        }

        private void OnClientResourceStart(string resourceName)
        {
            if (GetCurrentResourceName() != resourceName) return;

            checkLogin();

            RegisterCommand("register", new Action<int, List<object>, string>((source, args, raw) =>
            {
                TriggerServerEvent("register", args[0], args[1], args[2]);

            }), false);
        }

        private void login(string username, string email, string group, int temporal_id) 
        {
            string default_skin = config.GetStringValue("spawn_manager", "default_skin", "fallback").ToString();
            float x = float.Parse(config.GetStringValue("spawn_manager", "x", "fallback"));
            float y = float.Parse(config.GetStringValue("spawn_manager", "y", "fallback"));
            float z = float.Parse(config.GetStringValue("spawn_manager", "z", "fallback"));
            float heading = float.Parse(config.GetStringValue("spawn_manager", "heading", "fallback"));

            SpawnManager spawn = new SpawnManager();
            spawn.spawnPlayer(default_skin, x, y, z, heading);
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
                    gamenui.loginNui(false, false, false);
                    break;
                }
                else
                {
                  FreezeEntityPosition(PlayerPedId(), true);
                  gamenui.loginNui(true, false, false);

                }

            }
        }


    }
}
