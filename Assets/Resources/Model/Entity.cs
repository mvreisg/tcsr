using UnityEngine;

namespace Assets.Resources.Model
{
    public abstract class Entity
    {
        public delegate void NewPositionEventHandler(Vector3 position);
        public event NewPositionEventHandler Repositioned;

        private readonly Transform _transform;

        public Entity(Transform transform)
        {
            _transform = transform;
        }

        public Transform Transform => _transform;

        public abstract void Do();

        public void OnRepositioned(Vector3 position)
        {
            Repositioned?.Invoke(position);
        }
    }
}