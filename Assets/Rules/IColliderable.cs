using UnityEngine;

namespace Assets.Rules
{
    public interface IColliderable
    {
        Collider2D Collider2D { get; }
    }
}