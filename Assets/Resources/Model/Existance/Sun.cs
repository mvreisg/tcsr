using UnityEngine;

namespace Assets.Resources.Model.Existance
{
    public class Sun : Star
    {
        public Sun(Transform transform, Day day, float intensity) : base(transform, day, intensity)
        {

        }

        public override void Do()
        {
            base.Do();
            Intensity = Random.Range(0.5f, 1.0f);
        }
    }
}