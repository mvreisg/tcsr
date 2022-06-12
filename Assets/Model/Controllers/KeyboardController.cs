using UnityEngine;

namespace Assets.Model.Controllers
{
    public class KeyboardController : 
        IAct
    {
        public event IAct.ActEventHandler Acted;

        private bool _released;
        private bool _overridedByGUI;

        public void Update()
        {
            if (_overridedByGUI)
                return;

            float horizontal = Input.GetAxisRaw("Horizontal");
            if (horizontal < 0f)
            {
                Act(Action.BACK);
                _released = false;
            }
            else if (horizontal > 0f)
            {
                Act(Action.FORWARD);
                _released = false;
            }
            else if (horizontal == 0f && !_released)
            {
                Act(Action.STOP);
                _released = true;
            }
            else
                Act(Action.IDLE);
        }

        public void Act(Action action)
        {
            OnActed(new ActionInfo(null, action));
        }

        public void OnActed(ActionInfo actionInfo)
        {
            Acted?.Invoke(actionInfo);
        }

        public void ListenGUI(bool overridedByGUI)
        {
            _overridedByGUI = overridedByGUI;
        }
    }
}