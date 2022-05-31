using UnityEngine;

namespace Assets.Resources.Models.LightSources
{
    public class Sun : LightSource
    {
        private readonly Day _day;

        public Sun(Transform transform, Light light, Day day) : base(transform, light)
        {
            _day = day;
        }

        public override void Do()
        {
            Debug.Log("i shine based on the time");
        }
    }
}