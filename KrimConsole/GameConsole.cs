using KrimLibrary;
using System;

namespace KrimConsole
{
    public class GameConsole : IGamePlatform
    {
        //private Map _map;

        public void Run(string path)
        {
            Logger.Log("Загрузка консоли");
            //_map = new Map(path);
            //foreach (var line in _map.CellList)
            //{
            //    foreach (var charLine in line)
            //    {
            //        Console.Write(charLine + " ");
            //    }
            //    Console.WriteLine();
            //}
            //Console.ReadKey();
        }
    }
}
