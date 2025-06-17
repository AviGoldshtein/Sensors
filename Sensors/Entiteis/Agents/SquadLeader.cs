using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sensors.Entiteis.Agents
{
    internal class SquadLeader : IranianAgent
    {
        private int Counterattack;       //  not in use
        public SquadLeader(string rank, string[] requeredTypeSensors) : base(rank, requeredTypeSensors) { }

        public override void AttackBack()
        {
            MoveTheTurnForward();
            if (InvestigationManager._SingleInstance.AgentTurn % 3 == 0)
            {
                if (this.AttachedSensors.Count() > 0)
                {
                    int randomIndex = random.Next(this.AttachedSensors.Count());
                    this.AttachedSensors.RemoveAt(randomIndex);
                }
            }
        }

        public void TryRemoveRandomSensors()         //  not in use
        {
            if (Counterattack >= 3)
            {
                if (AttachedSensors.Count() > 0)
                {
                    int index = random.Next(AttachedSensors.Count() - 1);
                    AttachedSensors.RemoveAt(index);
                }
            }
            Counterattack = 0;
        }
    }
}
