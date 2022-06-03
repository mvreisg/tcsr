using System.Collections.Generic;
using UnityEngine;
using Assets.Resources.Model.Bio;

namespace Assets.Resources.Model.Existance
{
    public class Earth : Planet
    {
        private readonly List<LivingBeing> _livingBeings;

        public Earth(Transform transform, Atmosphere atmosphere, Day day) : base(transform, day, atmosphere)
        {
            _livingBeings = new List<LivingBeing>();
        }

        public List<LivingBeing> LivingBeings => _livingBeings;

        public override void Do()
        {
            base.Do();
            LivingBeings.ForEach(livingBeing => livingBeing.Do());
        }
    }
}