using UnityEngine;

namespace Assets.Resources.Model.Nature
{
    public class LightEmitter : Entity,
        ILight
    {
        private readonly Light _light;

        public LightEmitter(Transform transform) : base(transform)
        {
            _light = transform.GetComponent<Light>();
        }

        public Light Light => _light;

        public override void Do()
        {
            Debug.Log("LightEmitter...");
        }
    }
}