using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sensors.Serveces
{
    internal static class TimeCalculator
    {
        public static bool IsTheTimeThatPassedOkay(int limit, DateTime start, DateTime end)
        {
            int secondsPassed = end.Second - start.Second;
            if (secondsPassed < 0) secondsPassed += 60;
            return secondsPassed <= limit;
        }
    }
}
