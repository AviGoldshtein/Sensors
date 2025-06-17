using Sensors.Entiteis;
using Sensors.Entiteis.Agents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sensors.Factorys
{
    internal static class IranianAigentFactory
    {
        public static string[] Ranks = { "Foot", "Squad", "Senior", "Organization" };
        public static string[] TypeOfSensors = { "Audio", "Thermal", "Pulse", "Motion", "Magnetic", "Signal", "Light" };

        public static IranianAgent CreateRandomAgent(Random rnd)
        {
            int capasity = 0;

            string rank = Ranks[rnd.Next(Ranks.Length)];
            switch (rank)
            {
                case "Foot":
                    capasity = 2;
                    break;
                case "Squad":
                    capasity = 4;
                    break;
                case "Senior":
                    capasity = 6;
                    break;
                case "Organization":
                    capasity = 8;
                    break;
            }
            string[] RequiredSensorTypes = new string[capasity];

            for (int i = 0; i < capasity; i++)
            {
                RequiredSensorTypes[i] = TypeOfSensors[rnd.Next(TypeOfSensors.Length)];
            }

            IranianAgent agent = new IranianAgent(rank, RequiredSensorTypes);
            return agent;
        }




        public static string[] GetWeaknesSensorsArray(int length, Random rnd)
        {
            string[] weaknesSensors = new string[length];
            for (int i = 0; i < length; i++)
            {
                weaknesSensors[i] = TypeOfSensors[rnd.Next(TypeOfSensors.Length)];
            }
            return weaknesSensors;
        }
        public static IranianAgent CreateAgentOfType(string type, Random rnd)
        {
            int length = 0;
            switch (type)
            {
                case "Foot":
                    length = 2;
                    return new FootSoldier(type, GetWeaknesSensorsArray(length, rnd));
                case "Squad":
                    length = 4;
                    return new SquadLeader(type, GetWeaknesSensorsArray(length, rnd));
                case "Senior":
                    length = 6;
                    return new SeniorCommander(type, GetWeaknesSensorsArray(length, rnd));
                case "Organization":
                    length = 8;
                    return new OrganizationLeader(type, GetWeaknesSensorsArray(length, rnd));
            }
            return new IranianAgent(type, GetWeaknesSensorsArray(length, rnd));
        }
    }
}
