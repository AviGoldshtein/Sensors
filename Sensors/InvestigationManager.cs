using Sensors.Entiteis;
using Sensors.Factorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sensors
{
    internal class InvestigationManager
    {
        public void run()
        {
            Random rnd = new Random();

            IranianAgent iranian = IranianAigentFactory.CreateRandomAgent(rnd);
            //Console.WriteLine(iranian);

            
            
            //Console.WriteLine(sensor);

            for (int i = 0; i < 7; i++)
            {
                BaseSensor sensor = SensorFactory.CreateRandomSensor(rnd);
                iranian.AttachSensor(sensor);
            }
            
            Console.WriteLine(iranian);
            //sensor.Activate(iranian);


            BaseSensor sensor2 = SensorFactory.CreateRandomSensor(rnd);
            iranian.AttachSensor(sensor2);

            sensor2.Activate(iranian);
        }
    }
}
