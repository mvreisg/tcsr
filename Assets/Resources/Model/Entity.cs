using UnityEngine;

namespace Assets.Resources.Model
{
    public abstract class Entity
    {
        public delegate void RecycleEventHandler(Entity entity);
        public event RecycleEventHandler Recycled;

        public delegate void NewPositionEventHandler(Vector3 position);
        public event NewPositionEventHandler Repositioned;

        private readonly Transform _transform;

        public Entity(Transform transform)
        {
            Debug.Log($"Entity constructor: {GetType()}");
            _transform = transform;
        }

        public Transform Transform => _transform;

        public abstract void Do();

        public void OnRepositioned(Vector3 position)
        {
            Repositioned?.Invoke(position);
        }

        public void OnRecycled()
        {
            Recycled?.Invoke(this);
            Object.Destroy(Transform.gameObject);
        }
    }
}