using UnityEngine;

namespace Assets.Rules.Nature
{
    public class Earth : 
        IRule
    {
        private readonly Transform _transform;

        public Earth(Transform transform)
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