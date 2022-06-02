using UnityEngine;

namespace Assets.Resources.Model.Existance
{
    public class Earth : Planet
    {
        private readonly Day _day;

        public Day Day => _day;

        public Earth(Transform transform, Atmosphere atmosphere, Day day) : base(transform, atmosphere)
        {
            _day = day;
        }

        public override void Do()
        {
            base.Do();
            Day.Do();
        }
    }
}