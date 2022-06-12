using UnityEngine;
using Assets.Model.Belong;
using Assets.Model;

namespace Assets.Components.Entity
{
    public class BalloonComponent : MonoBehaviour,
        IEntityComponent
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

        public IEntity Entity => _balloon;

        private void FixedUpdate()
        {
            _balloon.FixedPhysics();
        }
    }
}