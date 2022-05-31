using UnityEngine;
using Assets.Resources.Models.People;

namespace Assets.Resources.Models.Creatures
{
    public abstract class Creature : Entity
    {
        private readonly Person _target;

        public Creature(Transform transform, Person target) : base(transform)
        {
            _target = target;
        }
    }
}