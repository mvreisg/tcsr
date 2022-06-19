using UnityEngine;

namespace Assets.Model
{
    public sealed class MovementInfo
    {
        private readonly IModel _entity;
        private readonly Vector3 _position;

        public MovementInfo(IModel entity, Vector3 position)
        {
            _entity = entity;
            _position = position;
        }

        public IModel Entity => _entity;

        public Vector3 Position => _position;
    }
}