using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sensors.Entiteis.Sensors
{
    internal class Light : BaseSensor
    {
        public Light(string name) : base(name) { }
        public override void Act(IranianAgent iranian)
        {
            Console.WriteLine($"\n{this.Name} sensor is revealung you 2 secrets:\n" +
                $"1. the rank of the solder is: {iranian.Type}\n" +
                $"2. this {iranian.Type} solder is affiliated to: {iranian.Affiliation}\n");
        }
    }
}
