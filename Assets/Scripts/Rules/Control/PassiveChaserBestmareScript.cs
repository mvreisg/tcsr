using System.Collections.ObjectModel;
using System.Collections.Generic;
using UnityEngine;
using Assets.Rules;
using Assets.Rules.Bio;
using Assets.Rules.Control;

namespace Assets.Scripts.Rules.Control
{
    public class PassiveChaserBestmareScript : MonoBehaviour,
        IRuleScript,
        IControlScript
    {
        private Bestmare _bestmare;
        private IOrder _passiveChaser;

        public IRule Rule => _bestmare;

        public ReadOnlyCollection<IOrder> Controllers
        {
            get
            {
                List<IOrder> controllers = new List<IOrder>();
                controllers.Add(_passiveChaser);
                return new ReadOnlyCollection<IOrder>(controllers);
            }
        }

        private void Awake()
        {
            _bestmare = new Bestmare(transform);
            _bestmare.Speed.X = Random.Range(0.3f, 0.9f);

            _passiveChaser = new PassiveChaser(transform);
            _passiveChaser.Ordered += _bestmare.ReceiveOrder;
        }

        private void Update()
        {
            _bestmare.Update();
        }
    }
}