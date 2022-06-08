using UnityEngine;

namespace Assets.Resources.Model.Controllers
{
    public class KeyboardController : Controller
    {
        private bool _released;

        public KeyboardController(Transform transform) : base(transform)
        {
            _released = true;    
        }

        public override void Do()
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
    }
}