using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sensors.Serveces
{
    internal static class FillLoger
    {
        public static void Log(string massage)
        {
            string logFilePath = "..\\..\\Data\\Logs.txt";
            string content = $"\n{DateTime.Now}: {massage}";
            File.AppendAllText(logFilePath, content);
        }
    }
}
