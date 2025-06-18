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
        public int TimeLimit = 5;

        // the agent you play with
        public IranianAgent AgentOnTheChair;
        public int AgentTurn;
        public int AgentId;

        // the agent in waiting room (optional)
        public IranianAgent AgentInWaitingRoom;
        public int AgentTurnInTheRoom;
        public int AgentIdInTheRoom;

        public void StartInvestigation(bool debug = false)
        {
            FillLoger.Log("investigation started");
            if (debug) Debuger._debug = true;

            UserTurn = 0;
            AgentTurn = 0;
            EnterNewAgentToRoom(IranianAigentFactory.CreateAgentOfType("Foot", Rand._random));
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
                if (AgentOnTheChair == null)
                {
                    Console.WriteLine("the room is empty, enter someone first");
                }
                else
                {
                    AgentOnTheChair.AttachSensor(sensor);
                }
            }
            else
            {
                Console.WriteLine("hey bro, to much time. try another time");
            }
        }
        public void EnterNewAgentToRoom(IranianAgent agent)
        {
            FillLoger.Log($"{agent.Type} agent entered the investigation room.");
            AgentTurn = 0;
            AgentId = -1;
            string RoomStatusMessage = this.AgentOnTheChair == null ? "entered an" : "changed the";
            this.AgentOnTheChair = agent;

            if (this.AgentOnTheChair != null)
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
            EnterNewAgentToRoom(IranianAigentFactory.CreateAgentOfType(TypeForNextLevel, Rand._random));
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
                    FillLoger.Log($"The limit time for every turn has been changed to {seconds} seconds.");
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
        public void SwapCurrentAgentWithNew()
        {
            MoveAgentToWaitingRoom();
            EnterNewAgentToRoom(IranianAigentFactory.CreateAgentOfType("Foot", Rand._random));
        }
        public void MoveAgentToWaitingRoom()
        {
            if (AgentOnTheChair != null)
            {
                AgentInWaitingRoom = AgentOnTheChair;
                AgentTurnInTheRoom = AgentTurn;
                AgentIdInTheRoom = AgentId;
                FillLoger.Log($"{AgentInWaitingRoom.Type} agent entered the waiting room.");
            }
            else
            {
                Console.WriteLine("There is no one on the chair");
            }
        }
        public void SwapAgentsBetweenChairAndRoom()
        {
            if (AgentOnTheChair != null)
            {
                if (AgentInWaitingRoom != null)
                {
                    IranianAgent tempCair = AgentInWaitingRoom;
                    int tempTurn = AgentTurnInTheRoom;
                    int tempId = AgentIdInTheRoom;

                    MoveAgentToWaitingRoom();

                    AgentOnTheChair = tempCair;
                    AgentTurn = tempTurn;
                    AgentId = tempId;

                    Console.WriteLine("The two agents switched.");
                }
                else
                {
                    Console.WriteLine("There is no one in the waiting room.");
                }
            }
            else
            {
                Console.WriteLine("There is no one on the chair.");
            }
        }
    }
}
