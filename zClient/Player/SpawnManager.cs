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
    internal class SpawnManager : BaseScript
    {
        public void spawnPlayer(float x, float y, float z, float heading)
        {
            RequestCollisionAtCoord(x, y, z);
            SetEntityCoordsNoOffset(PlayerPedId(), x, y, z, false, false, false);
            NetworkResurrectLocalPlayer(x, y, z, heading, true, true);
            ClearPedTasksImmediately(PlayerPedId());
            RemoveAllPedWeapons(PlayerPedId(), false);
            ClearPlayerWantedLevel(PlayerId());
        }
    }
}
