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

        public NUI()
        {

        }
        public void loginNui(bool open_nui)
        {
            string jsonString;
            if (open_nui == true){jsonString = "{\"showLoginMenu\": true }";}
            else {jsonString = "{\"showLoginMenu\": false }";}
            SendNuiMessage(jsonString);
        }
    }
}
