using UnityEngine;

namespace Assets.Model.Controllers
{
    public class KeyboardController : 
        IAct
    {
        public event IAct.ActEventHandler Acted;

        private bool _overridedByGUI;

        public void Update()
        {
            if (_overridedByGUI)
                return;

            float horizontal = Input.GetAxisRaw("Horizontal");
            if (horizontal < 0f)
                Act(Action.BACK);
            else if (horizontal > 0f)
                Act(Action.FORWARD);
            else
            {
                Act(Action.STOP);
                Act(Action.IDLE);
            }

            float use = Input.GetAxisRaw("Use");
            if (use > 0f)
                Act(Action.USE);
        }

        public void Act(Action action)
        {
            OnActed(new ActionInfo(this, action));
        }

        public void OnActed(ActionInfo info)
        {
            Acted?.Invoke(info);
        }

        public void ListenGUI(bool overridedByGUI)
        {
            _overridedByGUI = overridedByGUI;
        }
    }
}