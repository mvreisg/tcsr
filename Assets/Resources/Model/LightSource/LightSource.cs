using UnityEngine;

namespace Assets.Resources.Models.LightSources
{
    public abstract class LightSource : Entity
    {
        private readonly Light _light;
        private float _intensity;

        public Light Light => _light;

        public virtual float Intensity
        {
            get => _intensity;
            set => _intensity = value;
        }

        public LightSource(Transform transform, Light light) : base(transform)
        {
            _light = light;
        }
    }
}