// fivem imports
using CitizenFX.Core;
using System;
using static CitizenFX.Core.Native.API;

namespace zClient
{
    internal class NUI : BaseScript
    {
        ChatMessage chatmes = new ChatMessage();

        public NUI()
        {
            EventHandlers["gameNui"] += new Action<bool, bool, bool, string>(gameNui);
        }

        public void gameNui(bool open_nui, bool error, bool register_error, string app_s)
        {
            string jsonString;

            if (app_s == "editcharacter")
            {
                if (open_nui == true)
                {
                    jsonString = "{\"showcharacterDressNui\": true}";
                    SetNuiFocus(true, true);
                }
                else
                {
                    jsonString = "{\"showcharacterDressNui\": false }";
                    SetNuiFocus(false, false);
                }

                SendNuiMessage(jsonString);
            }

            if (app_s == "login")
            {
                if (open_nui == true)
                {
                    if (error == true)
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
                else
                {
                    jsonString = "{\"showLoginMenu\": false }";
                    SetNuiFocus(false, false);
                }

                SendNuiMessage(jsonString);
            }
        }


    }

}

