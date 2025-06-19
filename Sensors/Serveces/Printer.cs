using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sensors.Serveces
{
    internal static class Printer
    {
        public static void LogWelcoming(string massage)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(massage);
            Console.ResetColor();
        }
        public static void LogNote(string massage)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(massage);
            Console.ResetColor();
        }
        public static void LogError(string massage)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(massage);
            Console.ResetColor();
        }
        public static void LogWarnning(string massage)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(massage);
            Console.ResetColor();
        }
        public static void LogDebugging(string massage)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(massage);
            Console.ResetColor();
        }
        public static void LogSecret(string massage)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(massage);
            Console.ResetColor();
        }
    }
}
