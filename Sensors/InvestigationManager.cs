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
        private List<IranianAgent> PrisonCell = new List<IranianAgent>();
        public IranianAgent IranianOnTheChair;
        //public bool IsExsposed;    // still not in use

        public void run()
        {
            Menu.ShowMenu(new Random(), this);
        }
        public void AtechSensorToManOnTheChair()
        {
            BaseSensor sensor = SensorFactory.CreateSensorByType(Menu.GetChoiceSensor());
            if (IranianOnTheChair == null)
            {
                Console.WriteLine("the room is empty, enter someone first");
            }
            else
            {
                IranianOnTheChair.AttachSensor(sensor);
            }
        }
        public void EnterAgentToTheRoom(IranianAgent agent)
        {
            string RoomStatusMessage = this.IranianOnTheChair == null ? "entered an" : "changed the";
            this.IranianOnTheChair = agent;

            if (this.IranianOnTheChair != null)
            {
                Console.WriteLine($"you have {RoomStatusMessage} agent in the room!");
            }
            else
            {
                Console.WriteLine("for some reason the room is steel empty");
            }
        }
    }
}
