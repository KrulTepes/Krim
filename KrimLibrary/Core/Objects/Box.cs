using KrimLibrary.Core.Collisions;
using System.Collections.Generic;
using System.Drawing;

namespace KrimLibrary.Core.Objects
{
    public class Box : Tile
    {
        public Box(int x, int y)
        {
            Init(x, y, TileType.Box);
        }

        public bool TryMove(MoveType moveType)
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
                Position.X + movement.X,
                Position.Y + movement.Y);

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

                        SwapTiles.Swap(this, tile);
                        break;
                    }
                }
            }

           _position = tempPosition;
            return true;
        }
    }
}
