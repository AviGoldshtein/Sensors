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

        protected Random random = new Random();
        public string Type;

        protected string[] RequeredTypeSensors;
        protected List<BaseSensor> AttachedSensors = new List<BaseSensor>();

        public IranianAgent(string type, string[] requeredTypeSensors)
        {
            Type = type;
            RequeredTypeSensors = requeredTypeSensors;
        }

        public void AttachSensor(BaseSensor sensor)
        {
            AttachedSensors.Add(sensor);
            sensor.Activate(this);
        }
        public string[] GetRequeredTypeSensors() => this.RequeredTypeSensors;
        public List<BaseSensor> GetAttachedSensors() => this.AttachedSensors;
        public void SetRequeredTypeSensors(string[] requeredTypeSensors)
        {
            RequeredTypeSensors = requeredTypeSensors;
        }
        public void ClearAttachedSensors()
        {
            AttachedSensors.Clear();
        }
        public override string ToString()
        {
            return $"Rank: {Type}\n" +
                $"RequeredTypeSensors: {string.Join(", ", RequeredTypeSensors.ToList())}\n" +
                $"SensorsAttached: {string.Join(", ", AttachedSensors.ToList()) }\n";
        }
    }
}
