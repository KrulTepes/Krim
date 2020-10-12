using KrimLibrary;
using KrimWPF.Views;
using System;
using System.Windows;

namespace KrimWPF
{
    public class GameWPF : IGamePlatform
    {
        [STAThread]
        public void Run(string path)
        {
            Logger.Log("Загрузка графического окна");
            GameApplication app = new GameApplication();
            app.Path = path;
            app.Run();
        }
    }

    public class GameApplication : Application
    {
        public string Path { get; set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            GameWindow gameWindow;
            if (Path != string.Empty)
                gameWindow = new GameWindow(Path);
            else
                gameWindow = new GameWindow();

            gameWindow.Show();
        }
    }
}
