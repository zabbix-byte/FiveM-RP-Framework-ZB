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

                Vector3 cords = GetEntityCoords(PlayerPedId(), false);
                int cam = CreateCamWithParams("DEFAULT_SCRIPTED_CAMERA", cords.X+0.6f, cords.Y - 2.2f, cords.Z-0.15f, 0, 0, 0, GetGameplayCamFov(), true, 0);

                if (open_nui == true)
                {
                    jsonString = "{\"showcharacterDressNui\": true}";
                    SetNuiFocus(true, true);

                    ClearFocus();
                    SetEntityHeading(PlayerPedId(), 180);

                    SetCamActive(cam, true);
                    RenderScriptCams(true, true, 1000, true, false);

                }
                else
                {
    
                    jsonString = "{\"showcharacterDressNui\": false }";
                    SetNuiFocus(false, false);

                    ClearFocus();

                    RenderScriptCams(false, false, 0, true, false);
                    DestroyCam(cam, false);
                };

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

