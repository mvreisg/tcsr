using UnityEngine;

namespace Assets.Rules.Control
{
    public class KeyboardController : 
        IOrder
    {
        public event IOrder.OrderEventHandler Ordered;

        private bool _overridedByGUI;

        public void Update()
        {
            if (_overridedByGUI)
                return;

            float horizontal = Input.GetAxisRaw("Horizontal");
            if (horizontal < 0f)
            {
                Order(Action.TURN_BACK);
                Order(Action.BACK);
            }
            else if (horizontal > 0f)
            {
                Order(Action.TURN_FORWARD);
                Order(Action.FORWARD);
            }
            else
            {
                Order(Action.STOP);
                Order(Action.IDLE);
            }

            float use = Input.GetAxisRaw("Use");
            if (use > 0f)
                Order(Action.USE);
        }

        public void Order(Action action)
        {
            OnOrdered(new OrderInfo(this, action));
        }

        public void OnOrdered(OrderInfo info)
        {
            Ordered?.Invoke(info);
        }

        // Class originals

        public void ListenGUI(bool overridedByGUI)
        {
            _overridedByGUI = overridedByGUI;
        }
    }
}