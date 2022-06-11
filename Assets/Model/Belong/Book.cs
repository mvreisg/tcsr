using UnityEngine;

namespace Assets.Model.Belong
{
    public class Book :
        IEntity
    {
        public readonly Transform _transform;

        public Book(Transform transform)
        {
            _transform = transform;
        }

        public Transform Transform => _transform;

        public void Exist()
        {
            throw new UnityException();
        }

        public void OnRecycled()
        {
            throw new UnityException();
        }
    }
}