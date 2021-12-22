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
        public Admin() { EventHandlers["onLogin"] += new Action(onLogin); }

        private void onLogin()
        {
            if (this.group == "admin")
            {
                RegisterCommand("id", new Action<int, List<object>, string>((source, args, raw) => {
                    TriggerServerEvent("getUserInfo",  args[0].ToString());
                }), false);
            }
        }
    }
}
