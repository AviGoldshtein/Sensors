using Sensors.Entiteis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sensors.Data
{
    internal static class DalManager
    {
        public static DalAgents dalAgents = new DalAgents();
        public static DalSensors dalSensors = new DalSensors();
        public static DalConnectionJunction dalConnectionJunction = new DalConnectionJunction();

        public static void attachSensorToAgent(IranianAgent agent, int agentId, BaseSensor sensor)
        {
            if (agentId == -1)
            {
                agentId = dalAgents.InsertAgent(agent);
                InvestigationManager._SingleInstance.AgentId = agentId;
            }

            int sensorId = dalSensors.InsertSensor(sensor);
            dalConnectionJunction.InsertConnJanction(sensorId, agentId);
        }
    }
}
