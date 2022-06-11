using UnityEngine;

namespace Assets.Model.Nature
{
    public class LightEmitter : 
        IEntity,
        ILight
    {
        private readonly Transform _transform;
        private readonly Light _light;

        public LightEmitter(Transform transform)
        {
            _transform = transform;
            _light = transform.GetComponent<Light>();
        }

        public Transform Transform => _transform;

        public Light Light => _light;

        public void Exist()
        {
            throw new UnityException();
        }
    }
}