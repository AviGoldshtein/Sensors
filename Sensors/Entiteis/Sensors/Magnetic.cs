using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sensors.Entiteis.Sensors
{
    internal class Magnetic : BaseSensor
    {
        public Magnetic(string name) : base(name) { }
        public override void Act(IranianAgent iranian)
        {
            iranian.DontAttack -= 6;
        }
    }
}
