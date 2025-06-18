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
        public static string[] TypeOfSensors = { "Audio", "Thermal", "Pulse", "Motion", "Magnetic", "Signal", "Light" };    //  not in use

        public static BaseSensor CreateRandomSensor(Random rnd)   // not in use  //
        {
            string type = TypeOfSensors[rnd.Next(TypeOfSensors.Length)];
            BaseSensor sensor = new Audio(type);
            return sensor;
        }
        public static BaseSensor CreateSensorByType(string typeAsked)
        {
            switch (typeAsked)
            {
                case "Audio":
                    return new Audio(typeAsked);
                case "Thermal":
                    return new Thermal(typeAsked);
                case "Pulse":
                    return new Pulse(typeAsked);
                case "Motion":
                    return new Motion(typeAsked);
                case "Magnetic":
                    return new Magnetic(typeAsked);
                case "Signal":
                    return new Signal(typeAsked);
                case "Light":
                    return new Light(typeAsked);
            }
            return new Audio(typeAsked);
        }
    }
}
