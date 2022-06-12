using System.Collections.Generic;
using UnityEngine;
using Assets.Components;
using Assets.ScriptableObjects;
using System.Collections.ObjectModel;
using Assets.Components.Entity.Controllable;
using Assets.Model.Controllers;
using Assets.Model.Bio;

namespace Assets.Model.Nature
{
    public class Earth : 
        IEntity
    {
        private readonly Transform _transform;
        private readonly List<IEntity> _entities;

        public Earth(Transform transform)
        {
            _transform = transform;
            _entities = new List<IEntity>();
        }

        public Transform Transform => _transform;

        public void Exist()
        {

        }

        public void Instantiate(IScriptableObject scriptableObject, Vector3 position)
        {
            GameObject instance = Object.Instantiate(
                scriptableObject.Prefab,
                position,
                Quaternion.identity,
                Transform
            );

            IEntity entity = 
                instance.GetComponent<IEntityComponent>().Entity;

            IControllableEntityComponent component = instance.GetComponent<IControllableEntityComponent>();
            if (component != null)
            {
                ReadOnlyCollection<IAct> controllers = 
                    instance.GetComponent<IControllableEntityComponent>().Controllers;

                if (controllers != null)
                {
                    _entities.ForEach(e =>
                    {
                        foreach(IAct controller in controllers)
                        {
                            if (controller is ChaserAI && e is Human && e is IAct)
                                (e as IAct).Acted += (controller as ChaserAI).ListenAction;
                            if (controller is ChaserAI && e is Human && e is IMovable)
                                (e as IMovable).Moved += (controller as ChaserAI).ListenMovement;
                        }
                    });
                }
            }
            _entities.Add(entity);
        }
    }
}