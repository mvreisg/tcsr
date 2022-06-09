using UnityEngine;
using Assets.Model;
using Assets.Model.Nature;

namespace Assets.Components
{
    public class CandleFireRendererComponent : MonoBehaviour,
        IEntityComponent
    {
        private Fire _fire;

        public IEntity Entity => _fire;

        private void Awake()
        {
            _fire = new Fire(transform);
        }

        private void Update()
        {
            _fire.Do();
        }
    }
}