using UnityEngine;
using Assets.Model;
using Assets.Model.Nature;

namespace Assets.Components.Entity
{
    public class SunComponent : MonoBehaviour,
        IModelComponent
    {
        private Sun _sun;

        [SerializeField]
        private float _low;

        [SerializeField]
        private float _peak;

        public IModel Model => _sun;

        private void Awake()
        {
            _sun = new Sun(transform, _low, _peak);
        }

        private void Update()
        {
            _sun.Update();
        }
    }
}