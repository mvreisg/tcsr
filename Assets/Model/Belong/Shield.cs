using UnityEngine;

namespace Assets.Model.Belong
{
    public class Shield : Entity
    {
        public Shield(Transform transform) : base(transform)
        {

        }

        public override void Do()
        {
            Debug.Log("Shield...");
        }
    }
}