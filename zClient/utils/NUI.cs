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
    internal class NUI : BaseScript
    {
        ChatMessage chatmes = new ChatMessage();

        public NUI(){
            EventHandlers["loginNui"] += new Action<bool, bool>(loginNui);
        }

        public void loginNui(bool open_nui, bool error = false)
        {
            string jsonString;

            if (open_nui == true)
            {
                if (error == false)
                {
                    jsonString = "{\"showLoginMenu\": true}";
                }
                else
                {
                    jsonString = "{\"showLoginMenu\": true,  \"message\": \"The username or password is wrong\" }";
                }
                
                SetNuiFocus(true, true);
            }
            else { 
                jsonString = "{\"showLoginMenu\": false }";
                SetNuiFocus(false, false);
            }

            SendNuiMessage(jsonString);
        }
    }
}
