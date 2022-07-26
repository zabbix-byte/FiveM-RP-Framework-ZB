// fivem imports
using CitizenFX.Core;
using System;
using System.Collections.Generic;
using static CitizenFX.Core.Native.API;

namespace zClient
{
    /*
     * AUTH HANDLER SCRIPT
     * THIS HANDLE THE USER SPAWN ON THE SERVER AND THE AUTH PART
     */

    public class Auth : BaseScript
    {
        NUI gamenui = new NUI();
        IniFile config = new IniFile("ZombiLand", "config.ini");
        ChatMessage chatmes = new ChatMessage();
        SpawnManager spawn = new SpawnManager();

        public string username { get; set; }
        public string email { get; set; }
        public string group { get; set; }
        public int temporal_id { get; set; }

        public Auth()
        {
            EventHandlers["onClientResourceStart"] += new Action<string>(OnClientResourceStart);
            EventHandlers["login"] += new Action<string, string, string, int>(login);
        }

        private void OnClientResourceStart(string resourceName)
        {
            // LOGIC HANGLE
            if (GetCurrentResourceName() != resourceName) return;

            FreezeEntityPosition(PlayerPedId(), true);
            gamenui.gameNui(true, false, false, "login");
        }

        private void login(string username, string email, string group, int temporal_id)
        {
            // GETTING CONFIG
            float x = float.Parse(config.GetStringValue("spawn_manager", "x", "fallback"));
            float y = float.Parse(config.GetStringValue("spawn_manager", "y", "fallback"));
            float z = float.Parse(config.GetStringValue("spawn_manager", "z", "fallback"));
            float heading = float.Parse(config.GetStringValue("spawn_manager", "heading", "fallback"));
     
            // CHARGIN BASIC USER IN MEMORY
            this.username = username;
            this.email = email;
            this.group = group;
            this.temporal_id = temporal_id;


            // SPAWN THE USER
            loadPlayer(x, y, z, heading);


            // CLOSING NUI
            gamenui.gameNui(false, false, false, "login");
            FreezeEntityPosition(PlayerPedId(), false);

            // LOAD COMMADS AND MORE STUFF
            TriggerEvent("onLogin");
        }

        public void loadPlayer(float x, float y, float z, float h)
        {
            spawn.spawnPlayer(x, y, z, h);
            TriggerServerEvent("get_nose", this.temporal_id, this.username);
        }


    }


}
