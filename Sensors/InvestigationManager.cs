using Sensors.Entiteis;
using Sensors.Factorys;
using Sensors.Serveces;
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

        public int UserTurn;
        public int AgentTurn;
        public int AgentId;
        public int TimeLimit = 5;

        public IranianAgent IranianOnTheChair;

        public void StartInvestigation(bool debug = false)
        {
            if (debug) Debuger._debug = true;

            UserTurn = 0;
            AgentTurn = 0;
            EnterAgentToTheRoom(IranianAigentFactory.CreateAgentOfType("Foot", Rand._random));
            Menu.ShowMenu(this);
        }
        public void AtechSensorToManOnTheChair()
        {
            UserTurn++;
            Console.WriteLine($"your turn is: {UserTurn}.");
            Console.WriteLine($"you have {this.TimeLimit} seconds to decide.");
            DateTime startingPoint = DateTime.Now;

            BaseSensor sensor = SensorFactory.CreateSensorByType(Menu.GetChoiceSensor());
            DateTime endingPoint = DateTime.Now;

            if (TimeCalculator.IsTheTimeThatPassedOkay(this.TimeLimit, startingPoint, endingPoint))
            {
                if (IranianOnTheChair == null)
                {
                    Console.WriteLine("the room is empty, enter someone first");
                }
                else
                {
                    IranianOnTheChair.AttachSensor(sensor);
                }
            }
            else
            {
                Console.WriteLine("hey bro, to much time. try another time");
            }
        }
        public void EnterAgentToTheRoom(IranianAgent agent)
        {
            AgentTurn = 0;
            AgentId = -1;
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
            EnterAgentToTheRoom(IranianAigentFactory.CreateAgentOfType(TypeForNextLevel, Rand._random));
        }
        public void ChangeTheTimeLimit()
        {
            Console.WriteLine("Enter the number of seconds you want (2 - 8)");
            string choice = Console.ReadLine();
            if (int.TryParse(choice, out int seconds))
            {
                if (seconds <= 8 && seconds >= 2)
                {
                    this.TimeLimit = seconds;
                    Console.WriteLine($"you set the time limit to {seconds} seconds.");
                }
                else
                {
                    Console.WriteLine("only numbers between (2 - 8)");
                    ChangeTheTimeLimit();
                }
            }
            else
            {
                Console.WriteLine("enter only numbers");
                ChangeTheTimeLimit();
            }
        }
    }
}
