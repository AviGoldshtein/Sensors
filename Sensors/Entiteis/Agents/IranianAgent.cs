using Sensors.Serveces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sensors.Entiteis
{
    internal abstract class IranianAgent
    {
        public int DontAttack = 0;
        protected Random random = Rand._random;
        public string Type;
        public string Affiliation = "not implemented yet :-)";
        public string[] RequeredTypeSensors;
        protected List<BaseSensor> AttachedSensors = new List<BaseSensor>();
        public List<BaseSensor> AttachedSensoesToRemove = new List<BaseSensor>();

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
        public string[] GetWeaknesListSensors() => this.RequeredTypeSensors;
        public List<BaseSensor> GetAttachedSensors() => this.AttachedSensors;
        public void SetRequeredTypeSensors(string[] requeredTypeSensors)
        {
            RequeredTypeSensors = requeredTypeSensors;
        }
        public void ClearAttachedSensors()
        {
            AttachedSensors.Clear();
        }
        public abstract void AttackBack();
        public void MoveTheTurnForward()
        {
            InvestigationManager._SingleInstance.AgentTurn++;
            Debuger.LogDebugMessage($"{this.Type} is speakink: my turn number: {InvestigationManager._SingleInstance.AgentTurn}");
        }
        public override string ToString()
        {
            return $"Rank: {Type}\n" +
                $"RequeredTypeSensors: {string.Join(", ", RequeredTypeSensors.ToList())}\n" +
                $"SensorsAttached: {string.Join(", ", AttachedSensors.ToList()) }\n";
        }
    }
}
