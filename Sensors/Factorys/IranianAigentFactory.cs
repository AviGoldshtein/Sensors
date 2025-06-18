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
        //public static string[] Ranks = { "Foot", "Squad", "Senior", "Organization" };
        public static string[] TypeOfSensors = { "Audio", "Thermal", "Pulse", "Motion", "Magnetic", "Signal", "Light" };

        public static string[] GetWeaknesSensorsArray(string type, Random rnd)
        {
            int length = 0;
            switch (type)
            {
                case "Foot":
                    length = 2;
                    break;
                case "Squad":
                    length = 4;
                    break;
                case "Senior":
                    length = 6;
                    break;
                case "Organization":
                    length = 8;
                    break;
            }

            string[] weaknesSensors = new string[length];
            for (int i = 0; i < length; i++)
            {
                weaknesSensors[i] = TypeOfSensors[rnd.Next(TypeOfSensors.Length)];
            }
            return weaknesSensors;
        }
        public static IranianAgent CreateAgentOfType(string type, Random rnd)
        {
            switch (type)
            {
                case "Foot":
                    return new FootSoldier(type, GetWeaknesSensorsArray(type, rnd));
                case "Squad":
                    return new SquadLeader(type, GetWeaknesSensorsArray(type, rnd));
                case "Senior":
                    return new SeniorCommander(type, GetWeaknesSensorsArray(type, rnd));
                case "Organization":
                    return new OrganizationLeader(type, GetWeaknesSensorsArray(type, rnd));
            }
            return new FootSoldier(type, GetWeaknesSensorsArray(type, rnd));
        }
    }
}
