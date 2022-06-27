using UnityEngine;

namespace Assets.Rules
{
    public sealed class MovementInfo
    {
        private readonly IRule _entity;
        private readonly Vector3 _position;

        public MovementInfo(IRule entity, Vector3 position)
        {
            _entity = entity;
            _position = position;
        }

        public IRule Entity => _entity;

        public Vector3 Position => _position;
    }
}