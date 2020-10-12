using KrimLibrary;
using KrimWPF;
using System;
using System.Runtime.InteropServices;

namespace KrimConsole
{
    class Game
    {
        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        const int SW_HIDE = 0;
        const int SW_SHOW = 5;

        static IGamePlatform gamePlatform;
        static string mapPath = "maps/level1.txt"; // default level

        [STAThread]
        static void Main(string[] args)
        {
            Logger.LogSeparator();
            Logger.Log("Запуск программы");

            VisiblityConsole(false);
            gamePlatform = new GameWPF();

            foreach (string arg in args)
            {
                if (arg[0] == '-')
                {
                    if (arg == "-console")
                    {
                        VisiblityConsole(true);
                        gamePlatform = new GameConsole();
                    }
                }
                else
                {
                    mapPath = arg;
                }
            }

            gamePlatform.Run(mapPath);
        }

        private static void VisiblityConsole(bool visibility)
        {
            var handle = GetConsoleWindow();
            ShowWindow(handle, visibility == true ? SW_SHOW : SW_HIDE);
        }
    }
}
