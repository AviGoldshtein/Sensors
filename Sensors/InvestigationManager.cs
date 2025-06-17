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
        public static readonly InvestigationManager _SingleInstance = new InvestigationManager();

        //private List<IranianAgent> PrisonCell = new List<IranianAgent>();
        //public bool IsExsposed;    // still not in use

        public int UserTurn;
        public int AgentTurn;

        public IranianAgent IranianOnTheChair;

        public void StartInvestigation()
        {
            UserTurn = 0;
            AgentTurn = 0;
            EnterAgentToTheRoom(IranianAigentFactory.CreateAgentOfType("Foot", new Random()));
            Menu.ShowMenu(new Random(), this);
        }
        public void AtechSensorToManOnTheChair()
        {
            UserTurn++;
            Console.WriteLine($"your turn is: {UserTurn}");

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
            AgentTurn = 0;
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
        public void MoveToTheNextLevel(IranianAgent PreviousAgent)
        {
            string PreviousAgentType = PreviousAgent.Type;
            string TypeForNextLevel = "";
            switch (PreviousAgentType)
            {
                case "Foot":
                    TypeForNextLevel = "Squad";
                    break;
                case "Squad":
                    TypeForNextLevel = "Senior";
                    break;
                case "Senior":
                    TypeForNextLevel = "Organization";
                    break;
                default:
                    TypeForNextLevel = "Organization";
                    break;
            }
            EnterAgentToTheRoom(IranianAigentFactory.CreateAgentOfType(TypeForNextLevel, new Random()));
        }
    }
}
