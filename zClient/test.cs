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
    internal class test : BaseScript
    {
        public test()
        {
            EventHandlers["OnClientResourceStart"] += new Action<string>(OnClientResourceStart);
        }
        private void OnClientResourceStart(string resourceName)
        {
            RegisterCommand("echo", new Action<int, List<object>, string>((source, args, raw) => {
                TriggerServerEvent("test_event_name", $"{args[0]}");
            }), false);

            RegisterCommand("testdb", new Action<int, List<object>, string>((source, args, raw) => {
                TriggerServerEvent("dbtest");
            }), false);



        }
    }
}