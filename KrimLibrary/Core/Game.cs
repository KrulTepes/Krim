using KrimLibrary.Core.Collisions;
using KrimLibrary.Core.Entities;

namespace KrimLibrary.Core
{
    public class Game
    {
        private GameState _gameState;
        public GameState GameState { get => _gameState; }

        private Level _level;
        public Level Level { get => _level; }

        private Player _player;
        public Player Player { get => _player; }

        private int _countMove;
        public int CountMove { get => _countMove; }

        public Game()
        {
            Stop();
        }

        public Game(string path) : this()
        {
            LoadLevel(path);
        }

        public void LoadLevel(string path)
        {
            Logger.Log("Загрузка уровня...");
            _level = new Level(path);
        }

        public void Start()
        {
            if (!LevelLoadedCorrectly()) return;

            Logger.Log("Начало игры");

            // Спавн персонажа
            _player = new Player(Level.SpawnPoint);

            _gameState = GameState.Run;
        }

        public void Update(MoveType moveType)
        {
            if (!Player.Move(moveType)) return;

            CollisionManager.CallingAllHandlers();
            _countMove++;

            if (Player.IsEnd)
            {
                Win();
            }
        }

        public bool LevelLoadedCorrectly()
        {
            return (Level != null) && (Level.Tiles != null);
        }

        public void Stop()
        {
            _gameState = GameState.Stop;
        }

        private void Win()
        {
            _gameState = GameState.Win;
        }

        private void Loss()
        {
            _gameState = GameState.Death;
        }
    }
}
