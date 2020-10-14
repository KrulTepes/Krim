using KrimLibrary.Core.Collisions;
using System.Collections.Generic;
using System.Drawing;

namespace KrimLibrary.Core.Entities
{
    public abstract class Entity : ICollision
    {
        protected TileType tileType;
        protected Point position;
        protected CollisionType collisionType;

        public abstract object Owner { get; }
        public CollisionType CollisionType { get => collisionType; }
        public Point Position { get => position; }

        public Entity(Point position)
        {
            this.position = position;
        }

        public bool Move(MoveType moveType)
        {
            List<Collision> nearCollisions = CollisionManager.GetNearCollisions(this);

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
                        if (tile.CollisionType == CollisionType.Impassable) 
                            return false;

                        break;
                    }
                }
            }

            position = tempPosition;
            return true;
        }

        public void SetPosition(Point newPosition)
        {
            position = newPosition;
        }

        public virtual void NearCollision(List<Collision> collisions)
        {

        }

        public virtual void OnCollision(Collision collission)
        {

        }
    }
}
