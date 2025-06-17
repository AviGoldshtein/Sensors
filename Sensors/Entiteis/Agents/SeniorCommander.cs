using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sensors.Entiteis.Agents
{
    internal class SeniorCommander : IranianAgent
    {
        private int Counterattack;
        public SeniorCommander(string rank, string[] requeredTypeSensors) : base(rank, requeredTypeSensors) { }

        public void TryRemoveRandomSensors()
        {
            if (Counterattack >= 3)
            {
                for (int i = 0; i < 2; i++)
                {
                    if (AttachedSensors.Count() > 0)
                    {
                        int index = random.Next(AttachedSensors.Count() - 1);
                        AttachedSensors.RemoveAt(index);
                    }
                }
            }
            Counterattack = 0;
        }
    }
}
