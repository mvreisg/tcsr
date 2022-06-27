using UnityEngine;

namespace Assets.Rules.Items
{
    public class Shield :
        IRule
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