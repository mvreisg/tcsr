using UnityEngine;
using Assets.Model;
using Assets.Model.Nature;

namespace Assets.Components.Entity
{
    public class SunComponent : MonoBehaviour,
        IEntityComponent
    {
        private Sun _sun;

        public IEntity Entity => _sun;

        private void Awake()
        {
            _sun = new Sun(transform);
        }

        private void Update()
        {
            _sun.Exist();
        }
    }
}