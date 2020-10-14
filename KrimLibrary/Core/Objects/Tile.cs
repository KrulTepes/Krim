using KrimLibrary.Core.Collisions;
using System.Collections.Generic;
using System.Drawing;

namespace KrimLibrary.Core.Objects
{
    public abstract class Tile : ICollision
    {
        protected Point _position;
        public Point Position { get => _position; }
        public int X { get => _position.X; set => _position.X = value; }
        public int Y { get => _position.Y; set => _position.Y = value; }
        public TileType TileType { get; set; }

        private CollisionType _collisionType;
        public CollisionType CollisionType { get => _collisionType; }

        private object _owner;
        public object Owner { get => _owner; }

        protected void Init(int x, int y, TileType tileType)
        {
            _owner = this;
            X = x;
            Y = y;
            TileType = tileType;
            SetCollision(tileType);
            CollisionManager.AddCollision(this);
        }

        protected void SetCollision(TileType tileType)
        {
            switch (tileType)
            {
                case TileType.Floor:
                    _collisionType = CollisionType.Passable;
                    break;
                case TileType.Wall:
                    _collisionType = CollisionType.Impassable;
                    break;
                case TileType.Box:
                    _collisionType = CollisionType.Relocatable;
                    break;
                case TileType.Exit:
                    _collisionType = CollisionType.Passable;
                    break;
                default:
                    _collisionType = CollisionType.Undefind;
                    break;
            }
        }

        public void OnCollision(Collision collision)
        {

        }

        public void NearCollision(List<Collision> collisions)
        {

        }
    }
}
