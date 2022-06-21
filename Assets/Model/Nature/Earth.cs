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

        public void Update()
        {
            Debug.LogFormat("{0} knows {1} models.", Transform.name, _models.Count);
        }

        public void ListenSpawn(SpawnInfo info)
        {
            IModel spawned = info.Spawned;
            if (!spawned.Transform.IsChildOf(Transform))
            {
                Debug.LogFormat("{0} is not child of {1}", spawned.Transform.name, Transform.name);
                return;
            }
            if (_models.Contains(spawned))
            {
                Debug.LogFormat("{0} is already acknowledged by {1}", spawned.Transform.name, Transform.name);
                return;
            }
            _models.Add(spawned);
            Debug.LogFormat("Added to {0}: {1}", Transform.name, spawned.Transform.name);
        }

        public void ListenLate(LateInfo info)
        {
            IModel late = info.Late;
            bool removed = _models.Remove(late);
            if (removed)
                Debug.LogFormat("Departed from {0}: {1}", Transform.name, late.Transform.name);
            else
                Debug.LogFormat("Non-pertencent to {0}: {1}", Transform.name, late.Transform.name);
        }
    }
}