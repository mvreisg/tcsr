using UnityEngine;
using Assets.Rules;
using Assets.Rules.Bio;
using Assets.Rules.Control;

namespace Assets.Scripts.Control
{
    public class PlayerScript : MonoBehaviour,
        IRuleScript
    {
        private IRule _rule;
        private IRule _backButton;
        private IRule _forwardButton;
        private IRule _useButton;

        public IRule Rule => _rule;
        
        private void Awake()
        {
            _backButton = new BackButtonOrderer(transform);
            _backButton.Awake();

            _forwardButton = new ForwardButtonOrderer(transform);
            _forwardButton.Awake();

            _useButton = new UseButtonOrderer(transform);
            _useButton.Awake();

            _rule = new Human(transform);
            (_rule as IMovable).Speed.X = 2f;
            _rule.Awake();

            (_backButton as IOrder).Ordered += (_rule as IOrderListener).ListenOrder;
            (_forwardButton as IOrder).Ordered += (_rule as IOrderListener).ListenOrder;
            (_useButton as IOrder).Ordered += (_rule as IOrderListener).ListenOrder;
        }

        private void Start()
        {
            _backButton.Start();
            _forwardButton.Start();
            _useButton.Start();
            _rule.Start();
        }

        private void Update()
        {
            _backButton.Update();
            _forwardButton.Start();
            _useButton.Update();
            _rule.Update();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            (_rule as ICollision).OnCollisionEnter2D(collision);
        }
    }
}