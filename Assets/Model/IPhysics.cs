using UnityEngine;

namespace Assets.Model
{
    public interface IPhysics
    {
        Rigidbody2D Rigidbody2D { get; }
        XYZValue Force { get; }
        void FixedUpdate();
    }
}