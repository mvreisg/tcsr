using UnityEngine;

namespace Assets.Resources.Model.Bio
{
    public class Bestmare : Human
    {
        public Bestmare(Transform transform) : base(transform)
        {

        }

        public override void Do()
        {
            Debug.Log("Bestmare does something...");
        }
    }
}