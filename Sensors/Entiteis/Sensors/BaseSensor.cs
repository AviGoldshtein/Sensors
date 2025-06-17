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
        public Random random = new Random();
        public string Name { get; private set; }

        public BaseSensor(string name)
        {
            Name = name;
        }

        public void Activate(IranianAgent iranian)
        {
            bool allExposed = true;
            int counterExposedSensors = 0;
            Console.WriteLine(iranian);    // print for debugging

            bool nothingMatched;
            List<BaseSensor> tempStorege = new List<BaseSensor>();

            foreach (BaseSensor sensor in iranian.GetAttachedSensors())
            {
                sensor.Act(iranian);
            }

            foreach (string sensorWeaknes in iranian.GetWeaknesListSensors())
            {
                nothingMatched = true;
                foreach (BaseSensor sensor in iranian.GetAttachedSensors())
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
                    Console.WriteLine("somthing is missing in order to expose the agent");   //   for debugging
                    allExposed = false;
                }
            }
            Console.WriteLine($"exposed snesors: {counterExposedSensors} / {iranian.GetWeaknesListSensors().Length}\n");

            foreach (BaseSensor sensor in tempStorege)
            {
                iranian.GetAttachedSensors().Add(sensor);
            }

            foreach(BaseSensor sensorToRemove in iranian.AttachedSensoesToRemove)
            {
                iranian.GetAttachedSensors().Remove(sensorToRemove);
            }

            if (allExposed)
            {
                Console.WriteLine("\ncongragulations!!!\nthe agent is exposed\nyou are ready for the next level!\n\n");
                InvestigationManager._SingleInstance.MoveToTheNextLevel(iranian);
            }
            else
            {
                iranian.AttackBack();
            }
        }
        public virtual void Act(IranianAgent iranian)
        {
            Console.WriteLine($"{this.Name} is acting..............on {iranian.Type}");
        }
        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
