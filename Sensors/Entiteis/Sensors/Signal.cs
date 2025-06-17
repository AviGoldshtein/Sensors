using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sensors.Entiteis.Sensors
{
    internal class Signal : BaseSensor
    {
        public Signal(string name) : base(name) { }
        public override void Act(IranianAgent iranian)
        {
            Console.WriteLine($"{this.Name} sensor is revealung you a secret: the rank of the solder is: {iranian.Type}");
        }
    }
}
