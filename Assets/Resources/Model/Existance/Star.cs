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
            protected set => _intensity = value;
        }

        public Star(Transform transform, SpriteRenderer spriteRenderer, Light light, float intensity) : base(transform, spriteRenderer)
        {
            _light = light;
            Intensity = intensity;
        }
    }
}