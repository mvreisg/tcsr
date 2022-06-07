using UnityEngine;

namespace Assets.Resources.Model.Belong
{
    public abstract class Belonging : Entity,
        IRigidbody2D
    {
        private Vector3 _force;
        private readonly Rigidbody2D _rigidbody2D;

        public Belonging(Transform transform, Vector3 force) : base(transform)
        {
            _force = force;
            _rigidbody2D = transform.GetComponent<Rigidbody2D>();
        }

        public Vector3 Force => _force;

        public Rigidbody2D Rigidbody2D => _rigidbody2D;

        public void Gravity()
        {
            Rigidbody2D.AddForce(Force);
        }

        public override void Do()
        {
            Gravity();
        }
    }
}