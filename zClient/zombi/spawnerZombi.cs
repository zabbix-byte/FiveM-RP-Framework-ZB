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
    
    internal class spawnerZombi : Auth
    {

        zoneTypes zombi = new zoneTypes();
        public spawnerZombi()
        {
            EventHandlers["onClientResourceStart"] += new Action<string>(onClientResourceStart);
        }

        async private void onClientResourceStart(string resourceName)
        {
            if (GetCurrentResourceName() != resourceName) return;

            for (int i = 0; i < 100; i++)
            {
                await Delay(100);
                zombi.basic_zombi_model(-1056.315f - i, -2711.51f-i, 21.40f);
            }
            
        }
    }

}
