using Sensors.Entiteis.Sensors;
using Sensors.Serveces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sensors.Entiteis
{
    internal abstract class BaseSensor
    {
        protected Random random = Rand._random;
        public string Name { get; private set; }

        public BaseSensor(string name)
        {
            Name = name;
        }
        public abstract void Act(IranianAgent iranian);
        public void Activate(IranianAgent iranian)
        {
            bool allExposed = true;
            int counterExposedSensors = 0;
            Debuger.LogDebugMessage("\n" + iranian.ToString());

            bool noMatchFound;
            List<BaseSensor> tempStorege = new List<BaseSensor>();      // for a sensor that mathed once

            foreach (BaseSensor sensor in iranian.GetAttachedSensors())    // act every sesor once
            {
                sensor.Act(iranian);
            }

            int i = 0;
            foreach (string sensorWeaknes in iranian.GetWeaknesListSensors())    // look for every weaknes a sesor that can expose it
            {
                noMatchFound = true;
                foreach (BaseSensor sensor in iranian.GetAttachedSensors())
                {
                    if (sensor.Name == sensorWeaknes)
                    {
                        noMatchFound = false;
                        tempStorege.Add(sensor);             //  take out the sensor, so it dousnt expose another one
                        iranian.GetAttachedSensors().Remove(sensor);
                        Debuger.LogDebugMessage($"sensor weaknes number {i} found a match");
                        counterExposedSensors++;          //  to know how much is exposed
                        break;
                    }
                }
                if (noMatchFound)
                {
                    Debuger.LogDebugMessage($"sensor weaknes number {i} is missing a match");
                    allExposed = false;
                }
                i++;
            }
            Printer.LogNote($"exposed snesors: {counterExposedSensors} / {iranian.GetWeaknesListSensors().Length}\n");

            foreach (BaseSensor sensor in tempStorege)          // return all the sensors that have mached to some weaknes, and they are out for a while
            {
                iranian.GetAttachedSensors().Add(sensor);
            }

            foreach(BaseSensor sensorToRemove in iranian.AttachedSensoesToRemove)     //  in case some sensor hase been broken
            {
                iranian.GetAttachedSensors().Remove(sensorToRemove);
            }

            if (allExposed)
            {
                Printer.LogNote("\ncongragulations!!!\nthe agent is exposed\nyou are ready for the next level!\n\n");
                InvestigationManager._SingleInstance.MoveToTheNextLevel(iranian);
                FillLoger.Log($"{iranian.Type} agent has been exposed!");
            }
            else
            {
                iranian.AttackBack();
            }
        }
        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
