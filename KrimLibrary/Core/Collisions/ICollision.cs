using System.Collections.Generic;
using System.Drawing;

namespace KrimLibrary.Core.Collisions
{
    public interface ICollision
    {
        object Owner { get; }
        CollisionType CollisionType { get; }
        Point Position { get; }
        void OnCollision(Collision collission);

        void NearCollision(List<Collision> collisions);
    }
}
