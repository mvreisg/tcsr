using UnityEngine;

namespace Assets.Resources.Model.Nature
{
    public class Atmosphere : Entity
    {
        public Atmosphere(Transform transform) : base(transform)
        {

        }

        public override void Do()
        {
            Debug.Log("Atmosphere...");
        }
    }
}