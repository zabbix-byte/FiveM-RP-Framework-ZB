using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CitizenFX.Core;
using static CitizenFX.Core.Native.API;

namespace zClient
{
    internal class npcControl : BaseScript
    {
        
        public npcControl()
        {
            EventHandlers["onClientResourceStart"] += new Action<string>(onClientResourceStart);
        }
        
        async private void onClientResourceStart(string resourceName)
        {

            if (GetCurrentResourceName() != resourceName) return;

            while (true)
            {
                await Delay(0);
                Vector3 coords = GetEntityCoords(PlayerPedId(), false);
                disable_all(coords);
            }  
        }

        private void disable_all(Vector3 coords)
        {
            SetVehicleDensityMultiplierThisFrame(0f);
            SetRandomVehicleDensityMultiplierThisFrame(0f);
            SetParkedVehicleDensityMultiplierThisFrame(0f);
            SetPedDensityMultiplierThisFrame(0f);
            SetScenarioPedDensityMultiplierThisFrame(0f, 0f);
            SetPlayerWantedLevel(PlayerId(), 0, false);
            SetPlayerWantedLevelNow(PlayerId(), false);
            SetPlayerWantedLevelNoDrop(PlayerId(), 0, false);
            SetCreateRandomCops(false);
            SetCreateRandomCopsNotOnScenarios(false);
            SetCreateRandomCopsOnScenarios(false);
            SetGarbageTrucks(false);
            SetRandomBoats(false);
            ClearAreaOfVehicles(coords.X, coords.Y, coords.Z, 1000, false, false, false, false, false);
            RemoveVehiclesFromGeneratorsInArea(coords.X - 500.0f, coords.Y - 500.0f, coords.Z - 500.0f, coords.X + 500.0f, coords.Y + 500.0f, coords.Z + 500.0f, 0);
        }
    }
}
