using UnityEngine;

namespace Assets.Resources.Model.Existance
{
    public class Sun : Star
    {
        public Sun(Transform transform, SpriteRenderer spriteRenderer, Light light, float intensity) : base (transform, spriteRenderer, light, intensity)
        {

        }

        public override void Do()
        {
            Intensity = Random.Range(0f, 1f);
        }
    }
}