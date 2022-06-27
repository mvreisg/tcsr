using UnityEngine;

namespace Assets.Rules
{
    public interface IColliderable
    {
        Collider2D Collider2D { get; }

        void OnCollisionEnter2D(Collision2D collision);

        void OnTriggerEnter2D(Collider2D collider);
    }
}