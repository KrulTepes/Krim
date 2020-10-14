using KrimLibrary.Core.Objects;
using System.Collections.Generic;
using System.Drawing;

namespace KrimLibrary.Core
{
    public class Level
    {
        private Map _map;

        private Point _startPoint;
        public Point SpawnPoint { get => _startPoint; }
        public int Rows { get => _map.Height; }
        public int Columns { get => _map.Width; }
        public List<Tile> Tiles { get; set; }

        public Level(string path)
        {
            _map = new Map(path);
            if (_map.CellList == null) return;

            UpdateTiles();
        }

        public Tile GetTile(int x, int y)
        {
            if (Tiles.Count > _map.Width * y + x)
                return Tiles[_map.Width * y + x];

            return null;
        }

        private void UpdateTiles()
        {
            bool isFirst = false;
            if (Tiles == null)
            {
                Tiles = new List<Tile>(_map.Height * _map.Width);
                isFirst = true;
            }

            for (int y = 0; y < _map.Height; y++)
            {
                for (int x = 0; x < _map.Width; x++)
                {
                    if (_map.CellList[y][x] == 'S')
                        _startPoint = new Point(x, y);

                    if (!isFirst)
                    {
                        if (Tiles[_map.Width * y + x].TileType != DefineTileType(_map.CellList[y][x]))
                            Tiles[_map.Width * y + x] = DefineTile(x, y, _map.CellList[y][x]);
                    }
                    else
                        Tiles.Add(DefineTile(x, y, _map.CellList[y][x]));
                }
            }
        }

        private Tile DefineTile(int x, int y, char cell)
        {
            switch (cell)
            {
                case '.':
                    return new Floor(x, y);
                case 'X':
                    return new Wall(x, y);
                case 'K':
                    return new Box(x, y);
                case 'S':
                    return new Floor(x, y);
                case 'Q':
                    return new Exit(x, y);
            }

            return new Wall(x, y);
        }

        private TileType DefineTileType(char cell)
        {
            switch (cell)
            {
                case '.':
                    return TileType.Floor;
                case 'X':
                    return TileType.Wall;
                case 'K':
                    return TileType.Box;
                case 'S':
                    return TileType.Floor;
                case 'Q':
                    return TileType.Exit;
            }

            return TileType.Wall;
        }
    }
}