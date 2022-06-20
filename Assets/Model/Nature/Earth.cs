using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

namespace Assets.Model.Nature
{
    public class Earth : 
        IModel
    {
        private readonly Transform _transform;
        private readonly List<IModel> _models;

        public Earth(Transform transform)
        {
            _transform = transform;
            _models = new List<IModel>();
        }

        public Transform Transform => _transform;

        public ReadOnlyCollection<IModel> Models => new ReadOnlyCollection<IModel>(_models);

        public void Awake(){}

        public void Start(){}

        public void Update(){}

        public void ListenGeneration(GenerationInfo info)
        {
            IModel generated = info.Generated;
            if (!generated.Transform.IsChildOf(Transform) || _models.Contains(generated))
                return;
            _models.Add(generated);
            Debug.LogFormat("Generated {0}", generated.Transform.name);
        }

        public void ListenSpawn(SpawnInfo info)
        {
            IModel spawned = info.Spawned;
            if (!spawned.Transform.IsChildOf(Transform) || _models.Contains(spawned))
                return;
            _models.Add(spawned);
            Debug.LogFormat("Added {0}", spawned.Transform.name);
        }

        public void ListenLate(LateInfo info)
        {
            IModel late = info.Late;
            _models.Remove(late);
            Debug.LogFormat("Removed {0}", late.Transform.name);
        }
    }
}