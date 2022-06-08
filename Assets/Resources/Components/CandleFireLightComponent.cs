using UnityEngine;
using Assets.Resources.Model.Nature;

namespace Assets.Resources.Components
{
    public class CandleFireLightComponent : MonoBehaviour
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