using UnityEngine;
using Assets.Model;
using Assets.Model.Nature;

namespace Assets.Components.Entity
{
    public class EarthComponent : MonoBehaviour,
        IModelComponent
    {
        private Earth _earth;

        public IModel Model => _earth;

        private void Awake()
        {
            _earth = new Earth(transform);
            _earth.Awake();
        }

        private void Start()
        {
            _earth.Start();
        }

        private void Update()
        {
            _earth.Update();
        }
    }
}