using UnityEngine;
using Assets.Model;
using Assets.Model.Belong;

namespace Assets.Components.Model
{
    public class BalloonComponent : MonoBehaviour,
        IModelComponent
    {
        private Balloon _balloon;

        public IModel Model => _balloon;

        private void Awake()
        {
            _balloon = new Balloon(transform);
            _balloon.Awake();
        }

        private void Start()
        {
            _balloon.Start();
        }

        private void Update()
        {
            _balloon.Update();
        }

        private void FixedUpdate()
        {
            _balloon.FixedUpdate();
        }
    }
}