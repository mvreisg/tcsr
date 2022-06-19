using UnityEngine;

namespace Assets.Model.Belong
{
    public class Shield :
        IModel
    {
        public readonly Transform _transform;

        public Shield(Transform transform)
        {
            _transform = transform;
        }

        public Transform Transform => _transform;

        public void Awake()
        {
            
        }

        public void Start()
        {
            
        }

        public void Update()
        {
            
        }
    }
}