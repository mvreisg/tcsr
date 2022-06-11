using UnityEngine;

namespace Assets.Model.Controllers
{
    public class KeyboardController : 
        IAct
    {
        public event IAct.ActEventHandler Acted;

        private bool _released;

        public KeyboardController()
        {
            _released = true;
        }

        public void Update()
        {
            float horizontal = Input.GetAxisRaw("Horizontal");
            if (horizontal < 0f)
            {
                OnActed(Action.BACK);
                _released = false;
            }
            else if (horizontal > 0f)
            {
                OnActed(Action.FORWARD);
                _released = false;
            }
            else if (horizontal == 0f && !_released)
            {
                OnActed(Action.STOP);
                _released = true;
            }
            else
                OnActed(Action.IDLE);
        }

        public void OnActed(Action action)
        {
            Acted?.Invoke(action);
        }
    }
}