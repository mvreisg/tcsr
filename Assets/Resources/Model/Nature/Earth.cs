using System.Collections.Generic;
using UnityEngine;
using Assets.Resources.Model.Belong;
using Assets.Resources.Model.Bio;
using Assets.Resources.ScriptableObjects;

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

        public GameObject Instantiate(ScriptableObject scriptableObject, Vector3 position)
        {
            if (scriptableObject is BluScriptableObject)
                return Object.Instantiate(
                    (scriptableObject as BluScriptableObject).BluPrefab,
                    position,
                    Quaternion.identity,
                    Transform
                );
            else if (scriptableObject is BestmareScriptableObject)
                return Object.Instantiate(
                    (scriptableObject as BestmareScriptableObject).BestmarePrefab,
                    position,
                    Quaternion.identity,
                    Transform
                );
            else
                throw new UnityException($"unhandled state: {scriptableObject.name}");
        }

        public void Create(Belonging created)
        {
            _belongings.Add(created);
            OnCreated(created);
        }

        public void Destroy(Belonging destroyed)
        {
            _belongings.Remove(destroyed);
            OnDestroyed(destroyed);
        }

        public void Conceive(LivingBeing borning)
        {
            if (borning is Bestmare)
            {
                Bestmare bestmare = (Bestmare)borning;
                _livingBeings.ForEach(living =>
                {
                    if (living is Human)
                    {
                        living.Repositioned += bestmare.ListenHumanReposition;
                        Birth += bestmare.ListenHumanBirth;
                        Death += bestmare.ListenHumanDeath;
                    }
                });
            }
            _livingBeings.Add(borning);
            OnBirth(borning);
        }

        public void Kill(LivingBeing dying)
        {
            if (dying is Bestmare)
            {
                Bestmare bestmare = (Bestmare)dying;
                _livingBeings.ForEach(living =>
                {
                    if (living is Human)
                    {
                        living.Repositioned -= bestmare.ListenHumanReposition;
                        Birth -= bestmare.ListenHumanBirth;
                        Death -= bestmare.ListenHumanDeath;
                    }
                });
            }
            _livingBeings.Remove(dying);
            OnDeath(dying);
        }
    }
}