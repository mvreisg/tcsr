using UnityEngine;
using Assets.Resources.Model.Bio;
using Assets.Resources.Model.Controllers;

namespace Assets.Resources.Components
{
    public class BestmareComponent : MonoBehaviour
    {
        private Bestmare _bestmare;
        private ChaserIA _chaserIA;

        public Bestmare Bestmare => _bestmare;

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