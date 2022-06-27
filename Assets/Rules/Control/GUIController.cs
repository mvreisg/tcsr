using UnityEngine;
using Assets.Scripts.Pressable;

namespace Assets.Rules.Control
{
    public class GUIController : 
        IOrder
    {
        public event IOrder.OrderEventHandler Ordered;

        public delegate void GUIEventHandler(bool overriding);
        public event GUIEventHandler Overriden;

        private bool _back;
        private bool _forward;

        public GUIController(
            IPressableScript backButton, 
            IPressableScript forwardButton,
            IPressableScript useButton
        )
        {
            backButton.Down += ListenBackButtonDown;
            backButton.Up += ListenBackButtonUp;
            forwardButton.Down += ListenForwardButtonDown;
            forwardButton.Up += ListenForwardButtonUp;
            useButton.Down += ListenUseButtonDown;
            useButton.Up += ListenUseButtonUp;
            Override(false);
            Order(Action.STOP);
            Order(Action.IDLE);
        }

        private void ListenBackButtonDown()
        {
            if (_forward)
                return;
            Override(true);
            _back = true;
            Order(Action.TURN_BACK);
            Order(Action.BACK);
        }

        private void ListenBackButtonUp()
        {
            _back = false;
            Order(Action.STOP);
            Order(Action.IDLE);
            Override(false);
        }

        private void ListenForwardButtonDown()
        {
            if (_back)
                return;
            Override(true);
            _forward = true;
            Order(Action.TURN_FORWARD);
            Order(Action.FORWARD);
        }

        private void ListenForwardButtonUp()
        {
            _forward = false;
            Order(Action.STOP);
            Order(Action.IDLE);
            Override(false);
        }

        private void ListenUseButtonUp()
        {
            Order(Action.STOP);
            Order(Action.IDLE);
            Override(false);
        }

        private void ListenUseButtonDown()
        {
            Override(true);
            Order(Action.STOP);
            Order(Action.IDLE);
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

        private void Override(bool will)
        {
            OnOverriden(will);
        }

        private void OnOverriden(bool overriding)
        {
            Overriden?.Invoke(overriding);
        }
    }
}