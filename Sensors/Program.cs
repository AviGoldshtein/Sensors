using Sensors.Entiteis;
using Sensors.Entiteis.Sensors;
using Sensors.Factorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sensors
{
    internal class Program
    {
        static void Main(string[] args)
        {
            InvestigationManager investigation = new InvestigationManager();


            investigation.run();
        }
    }
}
