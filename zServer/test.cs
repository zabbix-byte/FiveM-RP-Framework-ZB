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
    internal class test : BaseScript
    {
        public test()
        {
            EventHandlers["onServerResourceStart"] += new Action<string>(OnServerResourceStart);
        }
        private void OnServerResourceStart(string resourceName)
        {
            EventHandlers["test_event_name"] += new Action<string>(testFunction);

        }

        private void testFunction(string test)
        {
            Console.WriteLine(test);
        }

    }
}
