using UnityEngine;

namespace Assets.Resources.Model
{
    public abstract class Entity
    {
        private readonly Transform _transform;

        public Entity(Transform transform)
        {
            _transform = transform;
        }

        public Transform Transform => _transform;

        public abstract void Do();
    }
}