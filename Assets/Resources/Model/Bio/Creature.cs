using UnityEngine;

namespace Assets.Resources.Model.Bio
{
    public abstract class Creature : LivingBeing
    {
        public Creature(Transform transform) : base(transform)
        {

        }
    }
}