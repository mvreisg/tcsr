using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;
using Assets.Resources.Model.Belong;
using Assets.Resources.Model.Bio;

namespace Assets.Resources.Model.Nature
{
    public class Earth : Entity
    {
        public delegate void BelongingEventHandler(Belonging belonging);
        public event BelongingEventHandler Created;
        public event BelongingEventHandler Destroyed;

        public delegate void LivingBeingEventHandler(LivingBeing livingBeing);
        public event LivingBeingEventHandler Birth;
        public event LivingBeingEventHandler Death;

        private readonly List<Belonging> _belongings;
        private readonly List<LivingBeing> _livingBeings;

        public Earth(Transform transform) : base(transform) 
        {
            _belongings = new List<Belonging>();
            _livingBeings = new List<LivingBeing>();
        }

        public ReadOnlyCollection<LivingBeing> LivingBeings => _livingBeings.AsReadOnly();

        public override void Do()
        {
            Debug.Log("Earth...");
        }

        private void OnCreated(Belonging belonging)
        {
            Created?.Invoke(belonging);
        }

        private void OnDestroyed(Belonging belonging)
        {
            Destroyed?.Invoke(belonging);
        }

        private void OnBirth(LivingBeing livingBeing)
        {
            Birth?.Invoke(livingBeing);
        }

        private void OnDeath(LivingBeing livingBeing)
        {
            Death?.Invoke(livingBeing);
        }

        public void Create(Belonging belonging)
        {
            _belongings.Add(belonging);
            OnCreated(belonging);
        }

        public void Destroy(Belonging belonging)
        {
            _belongings.Remove(belonging);
            OnDestroyed(belonging);
        }

        public void Conceive(LivingBeing livingBeing)
        {
            _livingBeings.Add(livingBeing);
            OnBirth(livingBeing);
        }

        public void Kill(LivingBeing livingBeing)
        {
            _livingBeings.Remove(livingBeing);
            OnDeath(livingBeing);
        }
    }
}