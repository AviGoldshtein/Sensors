using Sensors.Entiteis;
using Sensors.Entiteis.Sensors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sensors.Factorys
{
    internal static class SensorFactory
    {
        public static string[] TypeOfSensors = { "Audio", "Thermal", "Pulse", "Motion", "Magnetic", "Signal", "Light" };
        //public static Random rnd = new Random();


        public static BaseSensor CreateRandomSensor(Random rnd)
        {
            string type = TypeOfSensors[rnd.Next(TypeOfSensors.Length)];
            BaseSensor sensor = new Sensor(type);
            return sensor;
        }
    }
}
