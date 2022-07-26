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

    /*
     * THIS SCRIPT HAVE BASIC USER COMMADS
     */

    internal class AuthCommands : Auth
    {
        ChatMessage chatmes = new ChatMessage();
        public AuthCommands(){ EventHandlers["onLogin"] += new Action(onLogin);}

        private void onLogin()
        {
            RegisterCommand("logout", new Action<int, List<object>, string>((source, args, raw) => {TriggerServerEvent("logout", this.username); }), false);
            RegisterCommand("me", new Action<int, List<object>, string>((source, args, raw) => {
                chatmes.send($"Username: {this.username} Email: {this.email} Group: {this.group} Id: {this.temporal_id}");
            }), false);
        }

    }
}
