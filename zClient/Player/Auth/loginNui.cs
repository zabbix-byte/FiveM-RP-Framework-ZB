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

    internal class loginNui : Auth
    {
        NUI gamenui = new NUI();
        ChatMessage chatmes = new ChatMessage();

        public loginNui()
        {
            RegisterNuiCallbackType("login_nui");
            EventHandlers["__cfx_nui:login_nui"] += new Action<IDictionary<string, object>>(loginGameNui);
        }

        private void loginGameNui(IDictionary<string, object> data)
        {
            object username;
            object password;

            if (!data.TryGetValue("username", out username)) { gamenui.loginNui(true, false); return; }
            if (!data.TryGetValue("password", out password)) { gamenui.loginNui(true, false); return; }

            if (this.temporal_id > 0)
            {
                return;
            }
            else
            {
                TriggerServerEvent("login", username.ToString(), password.ToString(), GetPlayerServerId(PlayerId()));
                return;
            }

        }

    }
}
