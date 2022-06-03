using UnityEngine;

namespace Assets.Resources.Model.Controller
{
    public class InputPlayer : Player
    {
        public InputPlayer(Transform transform) : base(transform)
        {

        }

        public override void Do()
        {
            Debug.Log("Read player inputs here (keyboard, mouse, joystick, etc.)");
        }
    }
}