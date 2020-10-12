using KrimWPF.ViewModels;
using System.Windows;
using System.Windows.Input;

namespace KrimWPF.Views
{
    /// <summary>
    /// Логика взаимодействия для GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {
        private GameWindowViewModel viewModel;
        public GameWindow()
        {
            InitializeComponent();
            viewModel = new GameWindowViewModel();
            DataContext = viewModel;
        }

        public GameWindow(string path) : this()
        {
            viewModel.Load(path);
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            viewModel.KeyDownHandler(sender, e);
        }
    }
}
