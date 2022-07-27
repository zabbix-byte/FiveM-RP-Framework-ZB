using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// fivem imports
using CitizenFX.Core;
using static CitizenFX.Core.Native.API;

namespace zServer
{
    internal class spawnerZombi: BaseScript
    {

        public spawnerZombi()
        {
            EventHandlers["onClientResourceStart"] += new Action<string>(onClientResourceStart);
        }

        private void onClientResourceStart(string resourceName)
        {
            if (GetCurrentResourceName() != resourceName) return;

            

        }

    }
}
