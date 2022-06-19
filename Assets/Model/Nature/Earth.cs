using System.Collections.Generic;
using UnityEngine;
using Assets.Components.Entity;
using Assets.Components.Entity.Controllable;
using Assets.Model.Belong;
using Assets.Model.Bio;
using Assets.Model.Controllers;

namespace Assets.Model.Nature
{
    public class Earth : 
        IModel
    {
        private readonly Transform _transform;
        private readonly List<IModel> _existants;

        public Earth(Transform transform)
        {
            _transform = transform;
            _existants = new List<IModel>();
        }

        public Transform Transform => _transform;

        public void Awake()
        {
            
        }

        public void Start()
        {
            AcknowledgeExistants();
        }

        public void Update()
        {

        }

        private void AcknowledgeExistants()
        {
            Object[] components = Object.FindObjectsOfType<Object>();
            IModel model;
            foreach (Object c in components)
            {
                if (c is IModelComponent)
                {
                    model = (c as IModelComponent).Model;
                    if (_existants.Contains(model))
                        continue;
                    _existants.Add(model);
                }
            }
            _existants.ForEach(m => LinkExistants(m));
        }

        private void LinkExistants(IModel parameter)
        {
            foreach (IModel item in _existants)
            {
                if (parameter.Equals(item))
                    continue;

                IControllableComponent cmp = parameter.Transform.GetComponent<IControllableComponent>();
                if (cmp is not null)
                {
                    foreach (IAct controller in cmp.Controllers)
                    {
                        // ChaserAI linking
                        if (controller is ChaserAI && item is Human && item is IAct)
                        {
                            (item as IAct).Acted += (controller as ChaserAI).ListenAction;
                        }
                        if (controller is ChaserAI && item is Human && item is IMovable)
                        {
                            (item as IMovable).Moved += (controller as ChaserAI).ListenMovement;
                        }
                    }
                }

                if (item is IPicker && parameter is Book)
                    (item as IPicker).Picked += (parameter as Book).ListenPicking;

                if (item is Clock && parameter is SunLight)
                    (item as Clock).Ticked += (parameter as SunLight).ListenEarthClockTick;

                if (item is Clock && parameter is Sun)
                    (item as Clock).Ticked += (parameter as Sun).ListenEarthClockTick;
            }
        }

        public void ListenSpawn(SpawnInfo info)
        {
            IModel model = info.Spawned;
            LinkExistants(model);
            _existants.Add(model);
        }
    }
}