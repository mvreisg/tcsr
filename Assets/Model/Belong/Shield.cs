using UnityEngine;

namespace Assets.Model.Belong
{
    public class Shield :
        IEntity
    {
        public readonly Transform _transform;

        public Shield(Transform transform)
        {
            _transform = transform;
        }

        public Transform Transform => _transform;

        public void Update()
        {
            throw new UnityException();
        }
    }
}