using Sensors.Entiteis;
using Sensors.Factorys;
using Sensors.Serveces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Sensors
{
    internal static class Menu
    {
        public static void ShowMenu(InvestigationManager investigationManager)
        {
            string onOrOff;
            bool running = true;
            while (running)
            {
                onOrOff = Debuger._debug ? "off" : "on";

                Console.WriteLine("\n1. to attahc a sensor to the man seatting on the chair\n" +
                "2. to start a new game\n" +
                $"3. to turn {onOrOff} the debugging prints\n" +
                $"4. to change the time limit for every turn\n" +
                "1000. to exit the game\n");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        investigationManager.AtechSensorToManOnTheChair();
                        break;
                    case "2":
                        running = false;
                        InvestigationManager._SingleInstance.StartInvestigation(debug:Debuger._debug);
                        break;
                    case "3":
                        Debuger._debug = Debuger._debug ? false : true;
                        Console.WriteLine($"the debugging prints has been turned {onOrOff}");
                        break;
                    case "4":
                        InvestigationManager._SingleInstance.ChangeTheTimeLimit();
                        break;
                    case "1000":
                        running = false;
                        Console.WriteLine("have a good day");
                        break;
                    default:
                        Console.WriteLine("invalid input");
                        break;
                }
            }            
        }
        public static string GetChoiceSensor()
        {
            Console.WriteLine("1. Light\n" +
                "2. Signal\n" +
                "3. Magnetic\n" +
                "4. Motion\n" +
                "5. Pulse\n" +
                "6. Thermal\n" +
                "7. Audio\n");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    return "Light";
                case "2":
                    return "Signal";
                case "3":
                    return "Magnetic";
                case "4":
                    return "Motion";
                case "5":
                    return "Pulse";
                case "6":
                    return "Thermal";
                case "7":
                    return "Audio";
            }
            Console.WriteLine("invalid input");
            return GetChoiceSensor();
        }
    }
}
