using UnityEngine;

namespace Assets.Model
{
    public interface IColliderable
    {
        Collider2D Collider2D { get; }
    }
}