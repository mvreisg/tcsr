using UnityEngine;
using Assets.Model;
using Assets.Model.Bio;

namespace Assets.Components.Entity
{
    public class ChaserBestmareComponent : MonoBehaviour,
        IEntityComponent
    {
        private Bestmare _bestmare;

        public IEntity Entity => _bestmare;

        private void Awake()
        {
            _bestmare = new Bestmare(transform);
            _bestmare.Speed.X = Random.Range(0.3f, 0.9f);
        }

        private void Update()
        {
            _bestmare.Exist();
        }
    }
}