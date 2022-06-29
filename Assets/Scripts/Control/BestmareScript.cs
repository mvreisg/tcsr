using UnityEngine;
using Assets.Rules;
using Assets.Rules.Bio;
using Assets.Rules.Control;

namespace Assets.Scripts.Control
{
    public class BestmareScript : MonoBehaviour,
        IRuleScript
    {
        private IRule _passiveChaser;
        private IRule _bestmare;

        public IRule Rule => _bestmare;

        private void Awake()
        {
            _passiveChaser = new PassiveChaser(transform);
            _passiveChaser.Awake();
            (_passiveChaser as IOrder).Ordered += (_bestmare as IOrderListener).ListenOrder;
            
            _bestmare = new Bestmare(transform);
            _bestmare.Awake();
        }

        private void Start()
        {
            _passiveChaser.Start();
            _bestmare.Start();
        }

        private void Update()
        {
            _passiveChaser.Update();
            _bestmare.Update();
        }
    }
}