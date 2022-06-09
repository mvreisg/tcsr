using UnityEngine;
using Assets.Model;
using Assets.Model.Bio;
using Assets.Model.Controllers;

namespace Assets.Components
{
    public class ChaserBestmareComponent : MonoBehaviour,
        IEntityComponent
    {
        private Bestmare _bestmare;
        private ChaserIA _chaserIA;

        public IEntity Entity => _bestmare;

        private void Awake()
        {
            _bestmare = new Bestmare(transform);
            _bestmare.Speed.X = Random.Range(0.3f, 0.9f);
            _chaserIA = new ChaserIA(transform);
            _bestmare.ReadyToPursue += _chaserIA.ReceiveTarget;
            _chaserIA.Act += _bestmare.Act;
        }

        private void Update()
        {
            _bestmare.Do();
        }
    }
}