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
     * LOGIN AND REGISTER INTEFACE HANDLER
     */

    internal class loginNui : Auth
    {
        NUI gamenui = new NUI();
        ChatMessage chatmes = new ChatMessage();

        public loginNui()
        {
            RegisterNuiCallbackType("login_nui");
            RegisterNuiCallbackType("register_nui");
            EventHandlers["__cfx_nui:login_nui"] += new Action<IDictionary<string, object>, CallbackDelegate>(loginGameNui);
            EventHandlers["__cfx_nui:register_nui"] += new Action<IDictionary<string, object>>(RegisterGameNui);
        }

        private void loginGameNui(IDictionary<string, object> data, CallbackDelegate cb)
        {
            object username;
            object password;

            if (!data.TryGetValue("username", out username)) { gamenui.gameNui(true, false, false, "login"); cb(new { error = "Please insert the username!" }); return; }
            if (!data.TryGetValue("password", out password)) { gamenui.gameNui(true, false, false, "login"); cb(new { error = "Please insert the password!" }); return; }

            if (this.temporal_id > 0)
            {
                cb(new { error = "User is already login!" });
                return;
            }
            else
            {
                cb(new { error = "Try To login!" });
                TriggerServerEvent("login", username.ToString(), password.ToString(), GetPlayerServerId(PlayerId()));
                return;
            }

        }

        private void RegisterGameNui(IDictionary<string, object> data)
        {
            object username;
            object email;
            object password;

            if (!data.TryGetValue("username", out username)) { gamenui.gameNui(true, false, false, "login"); return; }
            if (!data.TryGetValue("email", out email)) { gamenui.gameNui(true, false, false, "login"); return; }
            if (!data.TryGetValue("password", out password)) { gamenui.gameNui(true, false, false, "login"); return; }

            if (this.temporal_id > 0)
            {
                return;
            }
            else
            {
                TriggerServerEvent("register", username.ToString(), email.ToString(), password.ToString());
                TriggerServerEvent("login", username.ToString(), password.ToString(), GetPlayerServerId(PlayerId()));
                return;
            }

        }

    }
}
