using Sensors.Entiteis;
using Sensors.Entiteis.Sensors;
using Sensors.Factorys;
using Sensors.Serveces;
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
            InvestigationManager investigationManager = InvestigationManager._SingleInstance;
            investigationManager.StartInvestigation(debug:true);
        }
    }
}
