using KrimLibrary.Core.Collisions;

namespace KrimLibrary
{
    public class Collision
    {
        public readonly object Object;
        public readonly CollisionType CollisionType;

        public Collision(CollisionType collisionType, object caller)
        {
            CollisionType = collisionType;
            Object = caller;
        }
    }
}
