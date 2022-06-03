using UnityEngine;

namespace Assets.Resources.Model.Controller
{
    public class GUIPlayer : Player
    {
        public GUIPlayer(Transform transform) : base(transform)
        {

        }

        public override void Do()
        {
            Debug.Log("Alert the characters if a GUI is pressed (back, forward, use, etc.) on the screen (touchscreen or mouse)");
        }
    }
}