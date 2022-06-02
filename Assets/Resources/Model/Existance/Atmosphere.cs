using UnityEngine;

namespace Assets.Resources.Model.Existance
{
    public class Atmosphere : Entity
    {
        public Atmosphere(Transform transform) : base(transform) {

        }

        public override void Do()
        {
            Debug.Log("I am the air, I am the sky, I belong to a Planet");
        }
    }
}