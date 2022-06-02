using UnityEngine;

namespace Assets.Resources.Model.Bio
{
    public class Blu : Human,
        IBoxCollider2D,
        IRigidbody2D
    {
        private readonly BoxCollider2D _boxCollider2D;
        private Vector3 _force;
        private readonly Rigidbody2D _rigidbody2D;

        public Blu(
            Transform transform, 
            XYZValue speed, 
            Multiplier x, 
            Multiplier y, 
            Multiplier z,
            Vector3 force) : 
            base(transform, speed, x, y, z)
        {
            _force = force;
            _boxCollider2D = transform.GetComponent<BoxCollider2D>();
            _rigidbody2D = transform.GetComponent<Rigidbody2D>();
        }

        public BoxCollider2D BoxCollider2D => _boxCollider2D;

        public Vector3 Force => _force;

        public Rigidbody2D Rigidbody2D => _rigidbody2D;

        public override void Do()
        {
            base.Do();
        }
    }
}