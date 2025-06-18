using Sensors.Factorys;
using Sensors.Serveces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sensors.Entiteis.Agents
{
    internal class OrganizationLeader : IranianAgent
    {
        public OrganizationLeader(string rank, string[] requeredTypeSensors) : base(rank, requeredTypeSensors) { }

        public override void AttackBack()
        {
            MoveTheTurnForward();
            if (this.DontAttack == 0)
            {
                if (InvestigationManager._SingleInstance.AgentTurn % 10 == 0)
                {
                    this.AttachedSensors.Clear();    // remove all ateched sensors
                    this.RequeredTypeSensors = IranianAigentFactory.GetWeaknesSensorsArray(this.Type, Rand._random);   // reset the weaknes list
                }
                if (InvestigationManager._SingleInstance.AgentTurn % 3 == 0)
                {
                    if (this.AttachedSensors.Count() > 0)
                    {
                        int randomIndex = random.Next(this.AttachedSensors.Count());
                        this.AttachedSensors.RemoveAt(randomIndex);
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
