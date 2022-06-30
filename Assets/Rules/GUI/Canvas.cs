using UnityEngine;

namespace Assets.Rules.GUI
{
    public class Canvas :
        IRule,
        ICanvas
    {
        private readonly Transform _transform;

        public Canvas(Transform transform)
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