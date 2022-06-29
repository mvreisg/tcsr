using UnityEngine;

namespace Assets.Rules
{
    public sealed class MovementInfo
    {
        private readonly IRule _rule;
        private readonly Vector3 _position;

        public MovementInfo(IRule entity, Vector3 position)
        {
            _rule = entity;
            _position = position;
        }

        public IRule Rule => _rule;

        public Vector3 Position => _position;
    }
}