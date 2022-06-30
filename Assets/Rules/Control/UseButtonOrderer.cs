using UnityEngine;
using Assets.Rules.GUI;
using Assets.Scripts.GUI;

namespace Assets.Rules.Control
{
    public class UseButtonOrderer :
        IRule,
        IOrder,
        IButtonListener
    {
        public event IOrder.OrderEventHandler Ordered;

        private readonly Transform _transform;

        public UseButtonOrderer(Transform transform)
        {
            _transform = transform;
        }

        public Transform Transform => _transform;

        public Orderers Type => Orderers.GUI;

        public void Awake()
        {

        }

        public void Start()
        {
            IRule rule = Object.FindObjectOfType<CanvasScript>().Canvas as IRule;
            rule.Transform.GetComponentInChildren<IUseButtonScript>().Button.StateChanged += ListenButton;
        }

        public void Update()
        {

        }

        public void Order(Action action)
        {
            OnOrdered(new OrderInfo(this, action));
        }

        public void OnOrdered(OrderInfo info)
        {
            Ordered?.Invoke(info);
        }

        public void ListenButton(ButtonInfo info)
        {
            Buttons button = info.Button;
            if (!button.Equals(Buttons.USE))
                return;
            bool pressed = info.Pressed;
            if (pressed)
            {
                Order(Action.STOP);
                Order(Action.USE);
                Order(Action.IDLE);
                return;
            }
        }
    }
}