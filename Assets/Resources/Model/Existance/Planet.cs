using UnityEngine;

namespace Assets.Resources.Model.Existance
{
    public abstract class Planet : CelestialBody
    {
        private readonly Atmosphere _atmosphere;

        public Atmosphere Atmosphere => _atmosphere;

        public Planet(Transform transform, SpriteRenderer spriteRenderer, Atmosphere atmosphere) : base(transform, spriteRenderer)
        {
            _atmosphere = atmosphere;
        }
    }
}