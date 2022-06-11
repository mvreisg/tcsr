using System.Collections.Generic;
using UnityEngine;
using Assets.Components;
using Assets.ScriptableObjects;

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
            throw new UnityException();
        }

        public void Instantiate(IScriptableObject scriptableObject, Vector3 position)
        {
            IEntity entity = Object.Instantiate(
                scriptableObject.Prefab,
                position,
                Quaternion.identity,
                Transform
            ).GetComponent<IEntityComponent>().Entity;
            _entities.Add(entity);
        }
    }
}