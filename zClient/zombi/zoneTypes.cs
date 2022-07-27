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
    internal class zoneTypes : BaseScript
    {

        uint basic_zombi = (uint)GetHashKey("u_m_y_zombie_01");

        public zoneTypes()
        {
            EventHandlers["onClientResourceStart"] += new Action<string>(onClientResourceStart);
        }

        async private void onClientResourceStart(string resourceName)
        {
            if (GetCurrentResourceName() != resourceName) return;

            while (HasModelLoaded(this.basic_zombi) == false)
            {
                RequestModel(this.basic_zombi);
                await Delay(100);
            }
        }

            public void basic_zombi_model(float x, float y, float z)
        {
            int zombi_p = CreatePed(4, this.basic_zombi, x, y, z, 0, true, true);
            SetPedCombatAttributes(zombi_p, 46, true);
            SetPedFleeAttributes(zombi_p, 0, false);
            SetPedAsEnemy(zombi_p, true);
            SetPedCombatRange(zombi_p, 2);
            SetPedAlertness(zombi_p, 3);
            SetPedConfigFlag(zombi_p, 224, true);
            SetPedCombatMovement(zombi_p, 3);
            SetPedRelationshipGroupHash(zombi_p, (uint)GetHashKey("HATES_PLAYER"));
        }
    }
}
