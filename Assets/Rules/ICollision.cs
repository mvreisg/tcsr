using UnityEngine;

namespace Assets.Rules
{
    public interface ICollision
    {
        delegate void CollisionEventHandler(CollisionInfo info);
        event CollisionEventHandler CollisionEntered;
        event CollisionEventHandler CollisionExited;

        void OnCollisionEnter2D(Collision2D collision);

        void OnCollisionExit2D(Collision2D collision);
    }
}