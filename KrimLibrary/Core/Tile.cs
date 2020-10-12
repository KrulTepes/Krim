using KrimLibrary.Core.Collisions;
using System.Collections.Generic;
using System.Drawing;

namespace KrimLibrary.Core
{
    public class Tile : ICollision
    {
        private Point _position;
        public Point Position { get => _position; }
        public int X { get => _position.X; set => _position.X = value; }
        public int Y { get => _position.Y; set => _position.Y = value; }
        public TileType TileType { get; set; }

        private CollisionType _collisionType;
        public CollisionType CollisionType { get => _collisionType; }

        public object Owner { get; }

        public Tile(TileType tileType)
        {
            CollisionManager.AddCollision(this);

            Owner = this;

            switch (tileType)
            {
                case TileType.Floor:
                    _collisionType = CollisionType.Passable;
                    break;
                case TileType.Wall:
                    _collisionType = CollisionType.Impassable;
                    break;
                case TileType.Exit:
                    _collisionType = CollisionType.Passable;
                    break;
                default:
                    _collisionType = CollisionType.Undefind;
                    break;
            }
        }


        public Tile(int x, int y, TileType tileType) : this(tileType)
        {
            SetTile(x, y, tileType);
        }

        public void SetTile(int x, int y, TileType tileType)
        {
            X = x;
            Y = y;
            TileType = tileType;
        }

        public void OnCollision(Collision collision)
        {

        }

        public void NearCollision(List<Collision> collisions)
        {
            
        }
    }
}
