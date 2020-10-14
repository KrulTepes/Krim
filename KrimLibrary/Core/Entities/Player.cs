using KrimLibrary.Core.Collisions;
using KrimLibrary.Core.Objects;
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

        public override bool Move(MoveType moveType)
        {
            List<Collision> nearCollisions = GetNearCollisions();
            Point movement;
            switch (moveType)
            {
                // ось инвертирована по оси Y
                case MoveType.Up:
                    movement = new Point(0, -1);
                    break;
                case MoveType.Down:
                    movement = new Point(0, 1);
                    break;
                case MoveType.Left:
                    movement = new Point(-1, 0);
                    break;
                case MoveType.Right:
                    movement = new Point(1, 0);
                    break;
                default:
                    movement = new Point();
                    break;
            }

            Point tempPosition = new Point(
                position.X + movement.X,
                position.Y + movement.Y);

            foreach (Collision collision in nearCollisions)
            {
                if (collision.Object is Tile)
                {
                    Tile tile = (Tile)collision.Object;
                    if (tile.Position.X == tempPosition.X &&
                        tile.Position.Y == tempPosition.Y)
                    {
                        if (collision.Object is Box)
                        {
                            if (!((Box)tile).TryMove(moveType))
                                return false;

                            break;
                        }

                        if (tile.CollisionType == CollisionType.Impassable)
                            return false;

                        break;
                    }
                }
            }

            position = tempPosition;
            return true;
        }

        public override void NearCollision(List<Collision> collisions)
        {

        }

        public override void OnCollision(Collision collission)
        {
            if (collission.Object is Exit)
            {
                _isEnd = true;
            }
        }

        public void Reset()
        {
            _isEnd = false;
        }
    }
}