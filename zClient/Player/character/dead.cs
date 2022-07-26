using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// fivem imports
using CitizenFX.Core;
using static CitizenFX.Core.Native.API;


namespace zClient.Player.character
{
    internal class dead : Auth
    {

        ChatMessage chatmes = new ChatMessage();

        public dead () {
            checkIfDead();
        }

        async private void checkIfDead()
        {

            int player_ped = GetPlayerPed(-1);
            while (true)
            {
                await Delay(1);
                if (IsEntityDead(PlayerPedId()) == true)
                {
                    await Delay(6);
                    chatmes.send("You are dead await");
                    this.loadPlayer(-1043.725f, -2748.829f, 21.36342f, 0f);
                }

            }

        }
    }
}
