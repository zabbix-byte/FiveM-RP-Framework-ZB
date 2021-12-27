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
            EventHandlers["loginNui"] += new Action<bool, bool, bool>(loginNui);
        }

        public void loginNui(bool open_nui, bool login_error, bool register_error)
        {
            string jsonString;

            if (open_nui == true)
            {
                if (login_error == true)
                {
                    if (register_error == true)
                    {
                        jsonString = "{\"showLoginMenu\": true,  \"message\": \"The username or email exists\" }";
                    }
                    else
                    {
                        jsonString = "{\"showLoginMenu\": true,  \"message\": \"The username or password is wrong\" }";
                    }
                    
                }
                else
                {
                    jsonString = "{\"showLoginMenu\": true}";
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

