using UnityEngine;

namespace Assets.Model
{
    public interface IRigidbody2D
    {
        Rigidbody2D Rigidbody2D { get; }
        Vector3 Force { get; }
        void FixedPhysics();
    }
}