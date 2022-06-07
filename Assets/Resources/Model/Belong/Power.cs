using UnityEngine;

namespace Assets.Resources.Model.Belong
{
    public abstract class Power : Belonging
    {
        public Power(Transform transform, Vector3 force) : base(transform, force){}

        public override void Do()
        {
            base.Do();
        }
    }
}