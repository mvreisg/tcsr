using UnityEngine;

namespace Assets.Resources.Model.Bio
{
    public class Bestmare : Human,
        IBoxCollider2D
    {
        private readonly BoxCollider2D _boxCollider2D;

        public Bestmare(
            Transform transform, 
            XYZValue speed,
            Multiplier x,
            Multiplier y,
            Multiplier z,
            Vector3 force) : 
            base(transform, speed, x, y, z, force)
        {
            _boxCollider2D = transform.GetComponent<BoxCollider2D>();
        }

        public BoxCollider2D BoxCollider2D => _boxCollider2D;

        public override void Do()
        {
            base.Do();
        }
    }
}