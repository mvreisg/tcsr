using UnityEngine;
using Assets.Model.Nature;

namespace Assets.Components
{
    public class SunlightComponent : MonoBehaviour
    {
        private LightEmitter _lightEmitter;

        private void Awake()
        {
            _lightEmitter = new LightEmitter(transform);
        }

        private void Update()
        {
            _lightEmitter.Do();
        }
    }
}