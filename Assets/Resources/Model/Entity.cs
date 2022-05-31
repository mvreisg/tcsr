using UnityEngine;

namespace Assets.Resources.Models
{
    public abstract class Entity
    {
        private Transform _transform;

        public Transform Transform => _transform;

        public Entity(Transform transform)
        {
            _transform = transform;
        }

        public abstract void Do();
    }
}