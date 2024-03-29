using UnityEngine;

namespace Assets.Rules.Nature
{
    public class Atmosphere : 
        IRule
    {
        private readonly Transform _transform;

        public Atmosphere(Transform transform)
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