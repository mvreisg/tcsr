using UnityEngine;
using Assets.Model;
using Assets.Model.Belong;

namespace Assets.Components
{
    public class CakeComponent : MonoBehaviour,
        IEntityComponent
    {
        private Cake _cake;

        public IEntity Entity => _cake;

        private void Awake()
        {
            _cake = new Cake(transform);
        }

        private void Update()
        {
            _cake.Do();
        }
    }
}