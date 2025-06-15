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
        protected int CountToActivate;
        protected string Name;

        public BaseSensor(string name)
        {
            Name = name;
        }




        public virtual void Activate(IranianAgent iranian)
        {
            bool nothingMatched;
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
                        Console.WriteLine("something matched");
                        break;
                    }
                }
                if (nothingMatched)
                {
                    Console.WriteLine("nothing matched");
                    break;
                }
            }

            foreach(BaseSensor sensor in tempStorege)
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
