using Sensors.Entiteis.Sensors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sensors.Entiteis
{
    internal abstract class BaseSensor
    {
        //protected int CountToActivate;
        protected string Name;

        public BaseSensor(string name)
        {
            Name = name;
        }

        public virtual void Activate(IranianAgent iranian)
        {
            bool allExposed = true;
            int counterExposedSensors = 0;
            // print for debugging
            Console.WriteLine(iranian);


            bool nothingMatched = true;
            List<BaseSensor> tempStorege = new List<BaseSensor>();

            foreach(string sensorWeaknes in iranian.GetRequeredTypeSensors())
            {
                nothingMatched = true;
                foreach(BaseSensor sensor in iranian.GetAttachedSensors())
                {
                    if (sensor.Name == sensorWeaknes)
                    {
                        nothingMatched = false;
                        tempStorege.Add(sensor);
                        iranian.GetAttachedSensors().Remove(sensor);
                        Console.WriteLine("something matched");       // for debugging
                        counterExposedSensors++;
                        break;
                    }
                }
                if (nothingMatched)
                {
                    Console.WriteLine("somthing is missing in order to expose the agent");
                    allExposed = false;
                }
            }
            Console.WriteLine($"you already exposed {counterExposedSensors} / {iranian.GetRequeredTypeSensors().Length}");
            if (allExposed)
            {
                Console.WriteLine("the agent is exposed");
            }

            foreach (BaseSensor sensor in tempStorege)
            {
                iranian.GetAttachedSensors().Add(sensor);
            }
        }
        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
