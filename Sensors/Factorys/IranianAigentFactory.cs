using Sensors.Entiteis;
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
        //public static Random rnd = new Random();
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
    }
}
