using UnityEngine;

namespace Assets.Model.Nature
{
    public class Atmosphere : 
        IEntity
    {
        private readonly Transform _transform;

        public Atmosphere(Transform transform)
        {
            _transform = transform;
        }

        public Transform Transform => _transform;

        public void Exist()
        {
            
        }
    }
}