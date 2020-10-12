using KrimLibrary.Core.Collisions;
using System.Collections.Generic;
using System.Drawing;

namespace KrimLibrary.Core.Entities
{
    public class Player : Entity
    {
        public TileType TileType { get => tileType; }

        public override object Owner { get; }

        private bool _isEnd;
        public bool IsEnd { get => _isEnd; }

        public Player(Point position) : base(position)
        {
            CollisionManager.AddCollision(this);
            _isEnd = false;
            Owner = this;
            tileType = TileType.Player;
        }

        public override void NearCollision(List<Collision> collisions)
        {

        }

        public override void OnCollision(Collision collission)
        {
            if (collission.Object is Tile)
            {
                Tile tile = (Tile)collission.Object;
                if (tile.TileType == TileType.Exit)
                {
                    _isEnd = true;
                }
            }
        }

        public void Reset()
        {
            _isEnd = false;
        }
    }
}