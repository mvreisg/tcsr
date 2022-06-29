using UnityEngine;

namespace Assets.Rules
{
    public sealed class CollisionInfo
    {
        private ICollision _invoker;
        private readonly Collision2D _collision;

        public CollisionInfo(ICollision invoker, Collision2D collision)
        {
            _invoker = invoker;
            _collision = collision;
        }

        public ICollision Invoker => _invoker;

        public Collision2D Collision => _collision;
    }
}