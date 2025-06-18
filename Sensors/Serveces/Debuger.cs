using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sensors.Serveces
{
    internal class Debuger
    {
        public static bool _debug = false;

        public static void LogDebugMessage(string massege)
        {
            if (_debug)
            {
                Console.WriteLine("\nDEBUGING: ");
                Console.WriteLine(massege + "\n");
            }
        }
    }
}
