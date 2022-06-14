using System.Collections.Generic;
using UnityEngine;
using Assets.Components.Entity;
using Assets.Components.Entity.Controllable;
using Assets.Model.Belong;
using Assets.Model.Bio;
using Assets.Model.Controllers;
using Assets.ScriptableObjects;

namespace Assets.Model.Nature
{
    public class Earth : 
        IEntity
    {
        private readonly Transform _transform;
        private readonly List<IEntity> _existants;

        public Earth(Transform transform)
        {
            _transform = transform;
            _existants = new List<IEntity>();
        }

        public Transform Transform => _transform;

        public void Update()
        {

        }

        public void AcknowledgeExistants()
        {
            Object[] components = Object.FindObjectsOfType<Object>();
            IEntity entity;
            foreach (Object obj in components)
            {
                if (obj is IEntityComponent)
                {
                    entity = (obj as IEntityComponent).Entity;
                    if (_existants.Contains(entity))
                        continue;
                    
                    if (_existants.Count > 0)
                        LinkEntity(entity);

                    _existants.Add(entity);
                }
            }
        }

        /// <summary>
        ///     <para>Will link the parameter Entity with another Entities</para>
        /// </summary>
        /// <param name="entity">The emitter or listener</param>
        private void LinkEntity(IEntity entity)
        {
            foreach (IEntity e in _existants)
            {
                // Linking controllers to entities
                IControllableComponent component =
                    entity.Transform.GetComponent<IControllableComponent>();

                if (component is not null)
                {
                    foreach (IAct controller in component.Controllers)
                    {
                        // ChaserAI linking
                        if (controller is ChaserAI && e is Human && e is IAct)
                        {
                            (e as IAct).Acted += (controller as ChaserAI).ListenAction;
                        }
                        if (controller is ChaserAI && e is Human && e is IMovable)
                        {
                            (e as IMovable).Moved += (controller as ChaserAI).ListenMovement;
                        }
                    }
                }

                // Link pickable to picker
                if (e is IPicker && entity is Book)
                {
                    (e as IPicker).Picked += (entity as Book).ListenPicking;
                }
            }
        }

        public void Instantiate(IScriptableObject scriptableObject, Vector3 position)
        {
            // Instantiate (prefab -> instance)
            GameObject instance = Object.Instantiate(
                scriptableObject.Prefab,
                position,
                Quaternion.identity,
                Transform
            );

            // Checks if it is a Entity Holder Component
            IEntityComponent component = instance.GetComponent<IEntityComponent>();
            if (component is null)
                return;

            // And get the entity
            IEntity entity = component.Entity;

            // New entity linking
            LinkEntity(entity);
            
            // Add the entity to the existance list
            _existants.Add(entity);
        }

        public void ListenSpawn(SpawnInfo info)
        {
            IEntity entity = info.Spawned;
            LinkEntity(entity);
            _existants.Add(entity);
        }
    }
}