using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CitizenFX.Core;
using static CitizenFX.Core.Native.API;

namespace zServer
{
    internal class spawnerZombi : BaseScript
    {
        uint basic_zombi = (uint)GetHashKey("u_m_y_zombie_01");

        public spawnerZombi()
        {
            EventHandlers["load_zombies"] += new Action<uint, int>(loadZombies);
        }

        private void loadZombies(uint zombi, int zombi_group)
        {


            
        }
    }

}
