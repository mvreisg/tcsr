using System.Collections.Generic;
using UnityEngine;
using Assets.Resources.Model.Belong;

namespace Assets.Resources.Model.Existance
{
    public abstract class Planet : CelestialBody
    {
        private readonly Atmosphere _atmosphere;
        private readonly List<Belonging> _belongings;

        public Planet(Transform transform, Day day, Atmosphere atmosphere) : base(transform, day)
        {
            _atmosphere = atmosphere;
            _belongings = new List<Belonging>();
        }

        public Atmosphere Atmosphere => _atmosphere;

        public List<Belonging> Belongings => _belongings;

        public override void Do()
        {
            base.Do();
            Atmosphere.Do();
            Belongings.ForEach(belonging => belonging.Do());
        }
    }
}