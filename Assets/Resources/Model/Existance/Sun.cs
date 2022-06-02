using UnityEngine;

namespace Assets.Resources.Model.Existance
{
    public class Sun : Star
    {
        public Sun(Transform transform, float intensity) : base(transform, intensity)
        {

        }

        public override void Do()
        {
            Intensity = Random.Range(0.5f, 1.0f);
        }
    }
}