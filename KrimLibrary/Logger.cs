using System;
using System.IO;

namespace KrimLibrary
{
    public static class Logger
    {
        private static string _path = AppDomain.CurrentDomain.BaseDirectory + "log.txt";

        public static void Log(string log)
        {
            using (StreamWriter sw = new StreamWriter(_path, true, System.Text.Encoding.UTF8))
            {
                sw.WriteLine($"{DateTime.Now}: {log}");
            }
        }

        public static void LogSeparator()
        {
            using (StreamWriter sw = new StreamWriter(_path, true, System.Text.Encoding.UTF8))
            {
                sw.WriteLine($"------------------------------------------------------------");
            }
        }
    }
}
