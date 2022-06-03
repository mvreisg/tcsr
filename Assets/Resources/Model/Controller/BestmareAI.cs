using UnityEngine;

namespace Assets.Resources.Model.Controller
{
    public class BestmareAI : AI
    {
        public BestmareAI(Transform transform) : base(transform)
        {

        }

        public override void Do()
        {
            Debug.Log("Control the Bestmare here");
        }
    }
}