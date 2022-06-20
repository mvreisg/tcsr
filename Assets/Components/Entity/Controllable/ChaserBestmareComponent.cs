using System.Collections.ObjectModel;
using System.Collections.Generic;
using UnityEngine;
using Assets.Model;
using Assets.Model.Bio;
using Assets.Model.Controllers;

namespace Assets.Components.Entity.Controllable
{
    public class ChaserBestmareComponent : MonoBehaviour,
        IModelComponent,
        IControllableComponent
    {
        private Bestmare _bestmare;
        private IAct _chaserAI;

        public IModel Model => _bestmare;

        public ReadOnlyCollection<IAct> Controllers
        {
            get
            {
                List<IAct> controllers = new List<IAct>();
                controllers.Add(_chaserAI);
                return new ReadOnlyCollection<IAct>(controllers);
            }
        }

        private void Awake()
        {
            _bestmare = new Bestmare(transform);
            _bestmare.Speed.X = Random.Range(0.3f, 0.9f);

            _chaserAI = new PassiveChaser(transform);
            // links the AI with the Bestmare
            _chaserAI.Acted += _bestmare.ReceiveOrder;
        }

        private void Update()
        {
            _bestmare.Update();
        }
    }
}