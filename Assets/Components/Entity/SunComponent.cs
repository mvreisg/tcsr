using UnityEngine;
using Assets.Model;
using Assets.Model.Nature;

namespace Assets.Components.Entity
{
    public class SunComponent : MonoBehaviour,
        IEntityComponent
    {
        private Sun _sun;

        [SerializeField]
        private float _low;

        [SerializeField]
        private float _peak;

        public IEntity Entity => _sun;

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