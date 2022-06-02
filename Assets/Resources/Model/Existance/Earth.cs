using UnityEngine;

namespace Assets.Resources.Model.Existance
{
    public class Earth : Planet
    {
        private readonly Day _day;

        public Day Day => _day;

        public Earth(Transform transform, SpriteRenderer spriteRenderer, Atmosphere atmosphere, Day day) : base(transform, spriteRenderer, atmosphere)
        {
            _day = day;
        }

        public override void Do()
        {
            Day.Do();
            Atmosphere.Do();
        }
    }
}