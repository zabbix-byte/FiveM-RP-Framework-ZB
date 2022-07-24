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
    internal class characterDressNui : Auth
    {
        ChatMessage chatmes = new ChatMessage();
        NUI gamenui = new NUI();

        public characterDressNui() { 
            EventHandlers["onLogin"] += new Action(onLogin);
            RegisterNuiCallbackType("editcharacter_nui");
            EventHandlers["__cfx_nui:editcharacter_nui"] += new Action<IDictionary<string, object>>(editCharacter);
        }

        // on user login 
        private void onLogin()
        {

            Game.Player.ChangeModel(GetHashKey("mp_m_freemode_01"));
            SetPedHeadBlendData(PlayerPedId(), 0, 0, 0, 0, 0, 0, 0, 0.5f, 0.5f, false);
            SetPedDefaultComponentVariation(PlayerPedId());

            RegisterCommand("character", new Action<int, List<object>, string>((source, args, raw) => {
                gamenui.gameNui(true, false, false, "editcharacter");
            }), false);

        }

        private async void desactive_editcharacter() { 
            gamenui.gameNui(false, false, false, "editcharacter");
            chatmes.send("no hace ni puto caso");
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

                return;
            }
            else
            {
                return;
            }

        }

    }
}
