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
     * CHARACTER CREATOR 
     * THIS SCRIPT IS USE TO CREATE A UNIQUE CHARACTER
     */

    internal class characterDressNui : Auth
    {
        ChatMessage chatmes = new ChatMessage();
        NUI gamenui = new NUI();
        int cam_zoom;

        public characterDressNui() { 
            EventHandlers["onLogin"] += new Action(onLogin);
            RegisterNuiCallbackType("editcharacter_nui");
            RegisterNuiCallbackType("editcharacter_nui_close");
            RegisterNuiCallbackType("rotateminus");
            RegisterNuiCallbackType("previewcharacter");
            RegisterNuiCallbackType("zoomface");
            RegisterNuiCallbackType("minface");
            RegisterNuiCallbackType("rotateplus");

            EventHandlers["__cfx_nui:rotateminus"] += new Action(rotateMinus);
            EventHandlers["__cfx_nui:rotateplus"] += new Action(rotatePlus);
            EventHandlers["__cfx_nui:editcharacter_nui"] += new Action<IDictionary<string, object>>(editCharacter);
            EventHandlers["__cfx_nui:editcharacter_nui_close"] += new Action(desactiveEditcharacter);
            EventHandlers["__cfx_nui:zoomface"] += new Action(zoomFace);
            EventHandlers["__cfx_nui:minface"] += new Action(minFace);
            EventHandlers["__cfx_nui:previewcharacter"] += new Action<IDictionary<string, object>>(previewCharacter);
        }

        // on user login 
        private void onLogin()
        {
            TriggerServerEvent("check_if_character_is_conf", this.username);
        }

        private void rotateMinus()
        {
            float r = GetEntityHeading(PlayerPedId());
            SetEntityHeading(PlayerPedId(), r-10);
        }

        private void rotatePlus()
        {
            float r = GetEntityHeading(PlayerPedId());
            SetEntityHeading(PlayerPedId(), r + 10);
        }

        private void zoomFace()
        {
            Vector3 cords = GetEntityCoords(PlayerPedId(), false);
            this.cam_zoom = CreateCamWithParams("DEFAULT_SCRIPTED_CAMERA", cords.X + 0.2f, cords.Y - 0.7f, cords.Z + 0.6f, 0, 0, 0, GetGameplayCamFov(), true, 0);
            ClearFocus();
            SetCamActive(this.cam_zoom, true);
            RenderScriptCams(true, true, 1000, true, false);
        }

        private void minFace()
        {
            ClearFocus();
            RenderScriptCams(false, false, 0, true, false);
            DestroyCam(this.cam_zoom, false);

            Vector3 cords = GetEntityCoords(PlayerPedId(), false);
            this.cam_zoom = CreateCamWithParams("DEFAULT_SCRIPTED_CAMERA", cords.X + 0.6f, cords.Y - 2.2f, cords.Z - 0.15f, 0, 0, 0, GetGameplayCamFov(), true, 0);
            ClearFocus();
            SetCamActive(this.cam_zoom, true);
            RenderScriptCams(true, true, 1000, true, false);
        }

        private void desactiveEditcharacter() { 
            gamenui.gameNui(false, false, false, "editcharacter");
            ClearFocus();
            RenderScriptCams(false, false, 0, true, false);
            TriggerServerEvent("get_nose", this.temporal_id, this.username);
        }


        private void previewCharacter(IDictionary<string, object> data)
        {
            object type;
            object value;


            if (!data.TryGetValue("type", out type)) { gamenui.gameNui(true, false, false, "editcharacter"); return; }
            if (!data.TryGetValue("value", out value)) { gamenui.gameNui(true, false, false, "editcharacter"); return; }

            if (type.ToString() == "nose_width") { TriggerServerEvent("preview_character", this.temporal_id, 0, (float)Int32.Parse(value.ToString())); }
            if (type.ToString() == "nose_peak") { TriggerServerEvent("preview_character", this.temporal_id, 1, (float)Int32.Parse(value.ToString())); }
            if (type.ToString() == "nose_length") { TriggerServerEvent("preview_character", this.temporal_id, 2, (float)Int32.Parse(value.ToString())); }
            if (type.ToString() == "nose_bone") { TriggerServerEvent("preview_character", this.temporal_id, 3, (float)Int32.Parse(value.ToString())); }
            if (type.ToString() == "nose_tip") { TriggerServerEvent("preview_character", this.temporal_id, 4, (float)Int32.Parse(value.ToString())); }
            if (type.ToString() == "nose_bone_twist") { TriggerServerEvent("preview_character", this.temporal_id, 5, (float)Int32.Parse(value.ToString())); }

        }
        private void editCharacter(IDictionary<string, object> data)
        {
            object nose_width;
            object nose_peak;
            object nose_length;
            object nose_bone;
            object nose_tip;
            object nose_bone_twist;

            if (!data.TryGetValue("nose_width", out nose_width)) { gamenui.gameNui(true, false, false, "editcharacter"); return; }
            if (!data.TryGetValue("nose_peak", out nose_peak)) { gamenui.gameNui(true, false, false, "editcharacter"); return; }

            if (!data.TryGetValue("nose_length", out nose_length)) { gamenui.gameNui(true, false, false, "editcharacter"); return; }
            if (!data.TryGetValue("nose_bone", out nose_bone)) { gamenui.gameNui(true, false, false, "editcharacter"); return; }
            if (!data.TryGetValue("nose_tip", out nose_tip)) { gamenui.gameNui(true, false, false, "editcharacter"); return; }
            if (!data.TryGetValue("nose_bone_twist", out nose_bone_twist)) { gamenui.gameNui(true, false, false, "editcharacter"); return; }

            int nose_width_int = Int32.Parse(nose_width.ToString());
            int nose_peak_int = Int32.Parse(nose_peak.ToString());
            int nose_length_int = Int32.Parse(nose_length.ToString());
            int nose_bone_int = Int32.Parse(nose_bone.ToString());
            int nose_tip_int = Int32.Parse(nose_tip.ToString());
            int nose_bone_twist_int = Int32.Parse(nose_bone_twist.ToString());

            if (this.temporal_id > 0)
            {
                TriggerServerEvent("update_nose", this.username, nose_width_int, nose_peak_int, nose_length_int, nose_bone_int, nose_tip_int, nose_bone_twist_int);
                TriggerServerEvent("get_nose", this.temporal_id, this.username);
            }

        }

    }
}
