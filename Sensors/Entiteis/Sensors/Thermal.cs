using Sensors.Serveces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sensors.Entiteis.Sensors
{
    internal class Thermal : BaseSensor
    {
        public Thermal(string name) : base(name) { }

        public override void Act(IranianAgent iranian)
        {
            int length = iranian.RequeredTypeSensors.Length;
            string SensorToReveal = iranian.RequeredTypeSensors[random.Next(length)];
            Printer.LogSecret($"{this.Name} sensor is revealung you a secret: one of the weaknes sensors is: {SensorToReveal}");
        }
    }
}
