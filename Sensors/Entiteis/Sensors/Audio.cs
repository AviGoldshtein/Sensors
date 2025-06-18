using Sensors.Serveces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sensors.Entiteis.Sensors
{
    internal class Audio : BaseSensor
    {
        public Audio(string name) :  base(name) { }
        public override void Act(IranianAgent iranian)
        {
            Debuger.LogDebugMessage($"{this.Name} is acting............on {iranian.Type}");
        }
    }
}
