using UnityEngine;
using Assets.Model;
using Assets.Model.Nature;

namespace Assets.Components.Entity
{
    public class SunLightComponent : MonoBehaviour,
        IModelComponent
    {
        private SunLight _sunLight;

        public IModel Model => _sunLight;

        private void Awake()
        {
            _sunLight = new SunLight(transform);
        }

        private void Update()
        {
            _sunLight.Update();
        }
    }
}