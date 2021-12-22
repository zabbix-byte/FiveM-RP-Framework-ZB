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
            EventHandlers["nui"] += new Action<string>(nui);
        }

        private void nui(string SerializeObject)
        {
            chatmes.send("Hola");
            SendNuiMessage(SerializeObject);
        }
    }
}
