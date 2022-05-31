using UnityEngine;
using Assets.Resources.Models.People;

namespace Assets.Resources.Models.Creatures
{
    public class Bestmare : Creature
    {
        public Bestmare(Transform transform, Person person) : base(transform, person)
        {

        }

        public override void Do()
        {
            Debug.Log("I persecute and hinder the target");
        }
    }
}