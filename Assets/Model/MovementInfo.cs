using UnityEngine;

namespace Assets.Model
{
    public sealed class MovementInfo
    {
        private readonly IEntity _entity;
        private readonly Vector3 _newPosition;

        public MovementInfo(IEntity entity, Vector3 newPosition)
        {
            _entity = entity;
            _newPosition = newPosition;
        }

        public IEntity Entity => _entity;

        public Vector3 NewPosition => _newPosition;
    }
}