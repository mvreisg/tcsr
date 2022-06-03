using System.Collections.Generic;
using UnityEngine;

namespace Assets.Resources.Model.Existance
{
    public class Universe : Entity
    {
        private readonly List<CelestialBody> _celestialBodies;

        public Universe(Transform transform) : base(transform)
        {
            _celestialBodies = new List<CelestialBody>();
        }

        public List<CelestialBody> CelestialBodies => _celestialBodies;

        public override void Do()
        {
            CelestialBodies.ForEach(celestialBody => celestialBody.Do());
        }
    }
}
