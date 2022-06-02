using UnityEngine;

namespace Assets.Resources.Model.Existance
{
    public abstract class Planet : CelestialBody
    {
        private readonly Atmosphere _atmosphere;

        public Atmosphere Atmosphere => _atmosphere;

        public Planet(Transform transform, Atmosphere atmosphere) : base(transform)
        {
            _atmosphere = atmosphere;
        }

        public override void Do()
        {
            Atmosphere.Do();
        }
    }
}