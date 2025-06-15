using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sensors.Entiteis
{
    internal class IranianAgent
    {
        //public static Dictionary<string, int> RanksAndCapasity = new Dictionary<string, int>();
        

        private string Rank;

        private string[] RequeredTypeSensors;
        private List<BaseSensor> AttachedSensors = new List<BaseSensor>();

        public IranianAgent(string rank, string[] requeredTypeSensors)
        {
            Rank = rank;
            RequeredTypeSensors = requeredTypeSensors;
        }

        public void AttachSensor(BaseSensor sensor)
        {
            AttachedSensors.Add(sensor);
        }

        public string[] GetRequeredTypeSensors() => this.RequeredTypeSensors;
        public List<BaseSensor> GetAttachedSensors() => this.AttachedSensors;
        public override string ToString()
        {
            return $"Rank: {Rank}\n" +
                $"RequeredTypeSensors: {string.Join(", ", RequeredTypeSensors.ToList())}\n" +
                $"SensorsAttached: {string.Join(", ", AttachedSensors.ToList()) }\n";
        }
    }
}
