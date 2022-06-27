using UnityEngine;
using Assets.Rules;
using Assets.Rules.Bio;
using Assets.Rules.Control;

namespace Assets.Scripts.Control
{
    public class BestmareScript : MonoBehaviour,
        IRuleScript
    {
        private IRule _rule;
        private IOrder _passiveChaser;

        public IRule Rule => _rule;

        private void Awake()
        {
            _rule = new Bestmare(transform);
            _rule.Awake();
            
            _passiveChaser = new PassiveChaser(transform);
            _passiveChaser.Ordered += (_rule as Bestmare).ReceiveOrder;
        }

        private void Start()
        {
            _rule.Start();
        }

        private void Update()
        {
            _rule.Update();
        }
    }
}