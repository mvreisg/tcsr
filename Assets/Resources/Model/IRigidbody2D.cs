using UnityEngine;

namespace Assets.Resources.Model
{
    public interface IRigidbody2D
    {
        Vector3 Force { get; }
        Rigidbody2D Rigidbody2D { get; }
    }
}