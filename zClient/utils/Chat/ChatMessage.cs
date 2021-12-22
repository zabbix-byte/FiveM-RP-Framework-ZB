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
    internal class ChatMessage : BaseScript
    {

        private string server_name;

        public ChatMessage() {
            EventHandlers["sendOnUserChat"] += new Action<string>(send);
            EventHandlers["onClientResourceStart"] += new Action<string>(onClientResourceStart); 
        }

        private void onClientResourceStart(string resourceName){ if (GetCurrentResourceName() != resourceName) return;}

        public void send(string message)
        {
            IniFile config = new IniFile("ZombiLand", "config.ini");

            server_name = config.GetStringValue("server_info", "server_name", "fallback");

            TriggerEvent("chat:addMessage", new
            {
                color = new[] { 255, 0, 0 },
                args = new[] { $"[{server_name}]", $"{message}" }
            });

        }
    }
}
