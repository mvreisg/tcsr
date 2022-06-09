using System.Collections.Generic;
using UnityEngine;
using Assets.Components;
using Assets.Model.Bio;
using Assets.ScriptableObjects;

namespace Assets.Model.Nature
{
    public class Earth : Entity
    {
        public delegate void EarthEventHandler(IEntity entity);
        public event EarthEventHandler Created;
        public event EarthEventHandler Destroyed;

        private readonly List<IEntity> _entities;

        public Earth(Transform transform) : base(transform)
        {
            _entities = new List<IEntity>();
        }

        public override void Do()
        {
            Debug.Log($"I acknowledge {_entities.Count} entities.");
        }

        private void OnCreated(IEntity entity)
        {
            Created?.Invoke(entity);
        }

        private void OnDestroyed(IEntity entity)
        {
            Destroyed?.Invoke(entity);
        }

        public void Instantiate(IScriptableObject scriptableObject, Vector3 position)
        {
            GameObject instance = Object.Instantiate(
                scriptableObject.Prefab,
                position,
                Quaternion.identity,
                Transform
            );
            Acknowledge(instance.GetComponent<IEntityComponent>().Entity);
        }

        public void Acknowledge(IEntity created)
        {
            if (created is Bestmare)
            {
                Bestmare bestmare = (Bestmare)created;
                _entities.ForEach(entity =>
                {
                    if (entity is Human)
                    {
                        entity.Repositioned += bestmare.ListenEntityReposition;
                        Created += bestmare.ListenEntityCreation;
                        Destroyed += bestmare.ListenEntityDestruction;
                    }
                });
            }
            _entities.Add(created);
            OnCreated(created);
        }

        public void Museum(IEntity destroyed)
        {
            if (destroyed is Bestmare)
            {
                Bestmare bestmare = (Bestmare)destroyed;
                _entities.ForEach(entity =>
                {
                    if (entity is Human)
                    {
                        entity.Repositioned -= bestmare.ListenEntityReposition;
                        Created -= bestmare.ListenEntityCreation;
                        Destroyed -= bestmare.ListenEntityDestruction;
                    }
                });
            }
            _entities.Remove(destroyed);
            OnDestroyed(destroyed);
        }
    }
}