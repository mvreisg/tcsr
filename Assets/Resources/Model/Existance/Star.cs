using UnityEngine;

namespace Assets.Resources.Model.Existance
{
    public abstract class Star : CelestialBody, 
        ILight
    {
        private readonly Light _light;
        private float _intensity;

        public Star(Transform transform, Day day, float intensity) : base(transform, day)
        {
            _light = transform.GetComponent<Light>();
            _intensity = intensity;
        }

        public Light Light => _light;

        public float Intensity
        {
            get => _intensity;
            set => _intensity = value;
        }

        public override void Do()
        {
            base.Do();
        }
    }
}