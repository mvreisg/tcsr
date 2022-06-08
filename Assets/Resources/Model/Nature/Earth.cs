using System.Collections.Generic;
using UnityEngine;
using Assets.Resources.Model.Bio;
using Assets.Resources.ScriptableObjects;
using Assets.Resources.Components;

namespace Assets.Resources.Model.Nature
{
    public class Earth : Entity
    {
        public delegate void EarthEventHandler(Entity entity);
        public event EarthEventHandler Created;
        public event EarthEventHandler Destroyed;

        private readonly List<Entity> _entities;

        public Earth(Transform transform) : base(transform)
        {
            _entities = new List<Entity>();
        }

        public override void Do()
        {
            Debug.Log("Earth...");
        }

        private void OnCreated(Entity entity)
        {
            Created?.Invoke(entity);
        }

        private void OnDestroyed(Entity entity)
        {
            Destroyed?.Invoke(entity);
        }

        public void Instantiate(ScriptableObject scriptableObject, Vector3 position)
        {
            GameObject instance;
            Entity entity;
            if (scriptableObject is HumanScriptableObject)
            {
                instance = Object.Instantiate(
                    (scriptableObject as HumanScriptableObject).Prefab,
                    position,
                    Quaternion.identity,
                    Transform
                );
                entity = instance.GetComponent<HumanComponent>().Human;
            }
            else if (scriptableObject is BestmareScriptableObject)
            {
                instance = Object.Instantiate(
                    (scriptableObject as BestmareScriptableObject).Prefab,
                    position,
                    Quaternion.identity,
                    Transform
                );
                entity = instance.GetComponent<BestmareComponent>().Bestmare;
            }
            else
                throw new UnityException($"unhandled state: {scriptableObject.name}");

            Create(entity);
        }

        public void Create(Entity created)
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

        public void Destroy(Entity destroyed)
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