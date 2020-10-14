using KrimLibrary;
using KrimLibrary.Core;
using KrimWPF.Models;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace KrimWPF.ViewModels
{
    class GameWindowViewModel : BaseViewModel
    {
        const int MIN_HEIGHT_FIELD_CELL = 50; // 75
        const int MIN_WIDTH_FIELD_CELL  = 50; // 75

        #region Properties
        private ObservableCollection<Image> _tilesCollection;
        public ObservableCollection<Image> TilesCollection
        {
            get
            {
                return _tilesCollection;
            }
            set
            {
                _tilesCollection = value;
                OnPropertyChanged("TilesCollection");
            }
        }

        private int _countMoves;
        public int CountMoves
        {
            get
            {
                return _countMoves;
            }

            set
            {
                _countMoves = value;
                OnPropertyChanged("CountMoves");
            }
        }

        private int _fieldRows;
        public int FieldRows
        {
            get
            {
                return _fieldRows;
            }

            set
            {
                _fieldRows = value;
                FieldHeight = MIN_HEIGHT_FIELD_CELL * value;
                OnPropertyChanged("FieldRows");
            }
        }

        private int _fieldColumns;
        public int FieldColumns
        {
            get
            {
                return _fieldColumns;
            }

            set
            {
                _fieldColumns = value;
                FieldWidth = MIN_WIDTH_FIELD_CELL * value;
                OnPropertyChanged("FieldColumns");
            }
        }

        private int _fieldWidth;
        public int FieldWidth
        {
            get
            {
                return _fieldWidth;
            }

            set
            {
                _fieldWidth = value;
                OnPropertyChanged("FieldWidth");
            }
        }

        private int _fieldHeight;
        public int FieldHeight
        {
            get
            {
                return _fieldHeight;
            }

            set
            {
                _fieldHeight = value;
                OnPropertyChanged("FieldHeight");
            }
        }

        private Visibility _menuVisibility;
        public Visibility MenuVisibility
        {
            get { return _menuVisibility; }
            set
            {
                _menuVisibility = value;
                OnPropertyChanged("MenuVisibility");
            }
        }
        #endregion

        private Game game;
        private ImageManager imageManager;

        public GameWindowViewModel()
        {
            imageManager = new ImageManager();

            game = new Game();
        }

        public void Load(string path)
        {
            game.LoadLevel(path);

            if (!game.LevelLoadedCorrectly())
            {
                Logger.Log("Неудалось загрузить уровень");
                return;
            }

            SwapTiles.tiles = game.Level.Tiles;

            FieldRows = game.Level.Rows;
            FieldColumns = game.Level.Columns;

            Logger.Log("Уровень загружен успешно");
        }

        public void Start()
        {
            game.Start();
            Update();
        }

        public void KeyDownHandler(object sender, KeyEventArgs e)
        {
            if (game.GameState == GameState.Run)
            {
                switch (e.Key)
                {
                    case Key.A: // Left
                        game.Update(MoveType.Left);
                        Update();
                        break;
                    case Key.D: // Right
                        game.Update(MoveType.Right);
                        Update();
                        break;
                    case Key.W: // Up
                        game.Update(MoveType.Up);
                        Update();
                        break;
                    case Key.S: // Down
                        game.Update(MoveType.Down);
                        Update();
                        break;
                }
            }
        }

        public void Update()
        {
            CountMoves = game.CountMove;
            TilesCollection = imageManager.UpdateCollection(TilesCollection, game.Level.Tiles, game.Player.Position.X, game.Player.Position.Y, game.Level.Columns);
            if (game.GameState == GameState.Win) {
                MessageBox.Show("WIN!!!!");
            }
        }

        public ICommand StartCommand
        {
            get
            {
                return new DelegateCommand(obj =>
                {
                    Start();
                    MenuVisibility = Visibility.Hidden;
                });
            }
        }
    }
}
