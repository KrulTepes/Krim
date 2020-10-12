using System.Collections.Generic;

namespace KrimLibrary.Core.Collisions
{
    static class CollisionManager
    {
        private static List<ICollision> _collisionsList = new List<ICollision>();

        public static void AddCollision(ICollision collision)
        {
            _collisionsList.Add(collision);
        }

        public static void CallingAllHandlers()
        {
            CallingOnHandlers();
            CallingNearHandlers();
        }

        public static void CallingOnHandlers()
        {
            foreach (ICollision collision in _collisionsList)
            {
                ICollision onCollision = _collisionsList.Find(el =>
                    collision.Position.X == el.Position.X &&
                    collision.Position.Y == el.Position.Y &&
                    !object.ReferenceEquals(collision.Owner, el.Owner));

                if (onCollision != null)
                    collision.OnCollision(new Collision(onCollision.CollisionType, onCollision.Owner));
            }
        }

        public static Collision GetOnCollision(ICollision collision)
        {
            ICollision onCollision = _collisionsList.Find(el =>
                collision.Position.X == el.Position.X &&
                collision.Position.Y == el.Position.Y);

            if (onCollision != null)
                return new Collision(onCollision.CollisionType, onCollision.Owner);

            return null;
        }

        public static void CallingNearHandlers()
        {
            foreach (ICollision collision in _collisionsList)
            {
                List<ICollision> nearCollisions = _collisionsList.FindAll(el =>
                    collision.Position.X == el.Position.X + 1 && collision.Position.Y == el.Position.Y     ||   // Right
                    collision.Position.X == el.Position.X - 1 && collision.Position.Y == el.Position.Y     ||   // Left
                    collision.Position.X == el.Position.X     && collision.Position.Y == el.Position.Y + 1 ||   // Down
                    collision.Position.X == el.Position.X     && collision.Position.Y == el.Position.Y - 1);    // Up

                List<Collision> collisions = new List<Collision>();

                foreach (ICollision nearCollision in nearCollisions)
                {
                    collisions.Add(new Collision(nearCollision.CollisionType, nearCollision.Owner));
                }

                if (nearCollisions != null)
                    collision.NearCollision(collisions);
            }
        }

        public static List<Collision> GetNearCollisions(ICollision collision)
        {
            List<ICollision> nearCollisions = _collisionsList.FindAll(el =>
                collision.Position.X == el.Position.X + 1 && collision.Position.Y == el.Position.Y ||   // Right
                collision.Position.X == el.Position.X - 1 && collision.Position.Y == el.Position.Y ||   // Left
                collision.Position.X == el.Position.X && collision.Position.Y == el.Position.Y + 1 ||   // Down
                collision.Position.X == el.Position.X && collision.Position.Y == el.Position.Y - 1);    // Up

            List<Collision> collisions = new List<Collision>();

            foreach (ICollision nearCollision in nearCollisions)
            {
                collisions.Add(new Collision(nearCollision.CollisionType, nearCollision.Owner));
            }

            if (nearCollisions != null)
                return collisions;

            return null;
        }
    }
}
