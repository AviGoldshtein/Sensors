using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sensors.Entiteis.Sensors
{
    internal class Pulse : BaseSensor
    {
        private int counterAttack = 0;
        public Pulse(string name) : base(name) { }

        public override void Act(IranianAgent iranian)
        {
            counterAttack++;
            if (counterAttack >= 3)
            {
                Console.WriteLine($"{this.Name} is speaking: Sorry, I am broken. On the way to the garbage");
                iranian.AttachedSensoesToRemove.Add(this);
            }
        }
    }
}
