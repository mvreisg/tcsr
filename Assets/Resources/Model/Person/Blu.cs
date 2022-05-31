using UnityEngine;

namespace Assets.Resources.Models.People
{
    public class Blu : Person
    {
        public Blu(Transform transform) : base(transform)
        {

        }

        public override void Do()
        {
            throw new UnityException("Blu.Do()");
        }
    }
}