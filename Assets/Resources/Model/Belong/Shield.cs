using UnityEngine;

namespace Assets.Resources.Model.Belong
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