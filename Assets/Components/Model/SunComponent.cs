using UnityEngine;
using Assets.Model;
using Assets.Model.Nature;

namespace Assets.Components.Model
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
            _sun.Awake();
        }

        private void Start()
        {
            _sun.Start();
        }

        private void Update()
        {
            _sun.Update();
        }
    }
}