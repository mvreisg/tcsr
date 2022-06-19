using UnityEngine;
using Assets.Model;
using Assets.Model.Belong;

namespace Assets.Components.Entity
{
    public class BalloonComponent : MonoBehaviour,
        IModelComponent
    {
        private Balloon _balloon;

        private void Awake()
        {
            _balloon = new Balloon(transform);
            (_balloon.Renderer as SpriteRenderer).color = new Color(
                Random.Range(0f, 1f),
                Random.Range(0f, 1f),
                Random.Range(0f, 1f)
            );
        }

        public IModel Model => _balloon;

        private void FixedUpdate()
        {
            _balloon.FixedUpdate();
        }
    }
}