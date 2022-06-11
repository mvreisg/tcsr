using UnityEngine;

namespace Assets.Model.Belong
{
    public class Balloon :
        IEntity
    {
        public readonly Transform _transform;

        public Balloon(Transform transform)
        {
            _transform = transform;
        }

        public Transform Transform => _transform;

        public void Exist()
        {
            throw new UnityException();
        }
    }
}