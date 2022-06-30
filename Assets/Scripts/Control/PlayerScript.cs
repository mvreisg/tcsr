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
        private IOrder _backButton;
        private IOrder _forwardButton;
        private IOrder _useButton;
        private IOrder _horizontalAxis;
        private IOrder _useAxis;

        public IRule Rule => _rule;
        
        private void Awake()
        {
            _backButton = new BackButtonOrderer(transform);
            (_backButton as IRule).Awake();

            _forwardButton = new ForwardButtonOrderer(transform);
            (_forwardButton as IRule).Awake();

            _useButton = new UseButtonOrderer(transform);
            (_useButton as IRule).Awake();

            _horizontalAxis = new HorizontalAxisOrderer(transform);
            (_horizontalAxis as IRule).Awake();

            _useAxis = new UseAxisOrderer(transform);
            (_useAxis as IRule).Awake();

            _rule = new Human(transform);
            (_rule as IMovable).Speed.X = 2f;
            _rule.Awake();

            _backButton.Ordered += (_rule as IOrderListener).ListenOrder;
            _forwardButton.Ordered += (_rule as IOrderListener).ListenOrder;
            _useButton.Ordered += (_rule as IOrderListener).ListenOrder;

            _horizontalAxis.Ordered += (_rule as IOrderListener).ListenOrder;
            _backButton.Ordered += (_horizontalAxis as IOrderListener).ListenOrder;
            _forwardButton.Ordered += (_horizontalAxis as IOrderListener).ListenOrder;
            _useButton.Ordered += (_horizontalAxis as IOrderListener).ListenOrder;

            _useAxis.Ordered += (_rule as IOrderListener).ListenOrder;
            _backButton.Ordered += (_useAxis as IOrderListener).ListenOrder;
            _forwardButton.Ordered += (_useAxis as IOrderListener).ListenOrder;
            _useButton.Ordered += (_useAxis as IOrderListener).ListenOrder;
        }

        private void Start()
        {
            (_backButton as IRule).Start();
            (_forwardButton as IRule).Start();
            (_useButton as IRule).Start();
            (_horizontalAxis as IRule).Start();
            (_useAxis as IRule).Start();
            _rule.Start();
        }

        private void Update()
        {
            (_backButton as IRule).Update();
            (_forwardButton as IRule).Update();
            (_useButton as IRule).Update();
            (_horizontalAxis as IRule).Update();
            (_useAxis as IRule).Update();
            _rule.Update();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            (_rule as ICollision).OnCollisionEnter2D(collision);
        }
    }
}