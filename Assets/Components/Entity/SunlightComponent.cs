using UnityEngine;
using Assets.Model;
using Assets.Model.Nature;

namespace Assets.Components.Entity
{
    public class SunlightComponent : MonoBehaviour,
        IModelComponent
    {
        private Sunlight _sunLight;

        public IModel Model => _sunLight;

        private void Awake()
        {
            _sunLight = new Sunlight(transform);
            _sunLight.Awake();
        }

        private void Start()
        {
            _sunLight.Start();
        }

        private void Update()
        {
            _sunLight.Update();
        }
    }
}