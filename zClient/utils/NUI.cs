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
            nui();
        }

        private void nui()
        {
            string jsonString = "{\"type\":\"enableui\",\"enable\":true}";
            SetNuiFocus(true, false);
            SendNuiMessage(jsonString);
        }
    }
}
