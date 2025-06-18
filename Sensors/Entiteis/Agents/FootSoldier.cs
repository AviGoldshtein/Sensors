using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sensors.Entiteis.Agents
{
    internal class FootSoldier : IranianAgent
    {
        public FootSoldier(string rank, string[] requeredTypeSensors) : base(rank, requeredTypeSensors) { }
        public override void AttackBack()
        {
            MoveTheTurnForward();
        }
    }
}
