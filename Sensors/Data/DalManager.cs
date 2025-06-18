using Sensors.Entiteis;
using Sensors.Serveces;
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
                FillLoger.Log($"A new agent has been entered into the database ({agent.Type})");
            }

            int sensorId = dalSensors.InsertSensor(sensor);
            FillLoger.Log($"A new sensor has been entered into the database ({sensor.Name})");
            dalConnectionJunction.InsertConnJanction(sensorId, agentId);
        }
    }
}
