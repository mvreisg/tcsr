using UnityEngine;

namespace Assets.Model
{
    public interface IPhysics
    {
        Rigidbody2D Rigidbody2D { get; }
        XYZValue Acceleration { get; }
        void FixedUpdate();
    }
}