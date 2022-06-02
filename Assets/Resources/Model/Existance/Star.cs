using UnityEngine;

namespace Assets.Resources.Model.Existance
{
    public abstract class Star : CelestialBody, ILight
    {
        private readonly Light _light;
        private float _intensity;

        public Light Light => _light;

        public float Intensity
        {
            get => _intensity;
            set => _intensity = value;
        }

        public Star(Transform transform, float intensity) : base(transform)
        {
            _intensity = intensity;
            _light = transform.GetComponent<Light>();
        }
    }
}