using UnityEngine;

namespace Assets.Model
{
    public interface IForce
    {
        Rigidbody2D Rigidbody2D { get; }
        Vector3 Force { get; }
        void FixedPhysics();
    }
}