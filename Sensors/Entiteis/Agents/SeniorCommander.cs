using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sensors.Entiteis.Agents
{
    internal class SeniorCommander : IranianAgent
    {
        public SeniorCommander(string rank, string[] requeredTypeSensors) : base(rank, requeredTypeSensors) { }

        public override void AttackBack()
        {
            MoveTheTurnForward();
            if (this.DontAttack == 0)
            {
                if (InvestigationManager._SingleInstance.AgentTurn % 3 == 0)
                {
                    for (int i = 0; i < 2; i++)
                    {
                        if (this.AttachedSensors.Count() > 0)
                        {
                            int randomIndex = random.Next(this.AttachedSensors.Count());
                            this.AttachedSensors.RemoveAt(randomIndex);
                        }
                    }
                }
            }
            else
            {
                this.DontAttack++;
            }
        }
    }
}
