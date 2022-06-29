using UnityEngine;

namespace Assets.Rules
{
    public interface ICollider
    {
        Collider2D Collider2D { get; }
    }
}