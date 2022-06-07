using UnityEngine;

namespace Assets.Resources.Model.Bio
{
    public class Bestmare : LivingBeing,
        IBoxCollider2D
    {
        private readonly BoxCollider2D _boxCollider2D;
        
        private Vector3 _target;

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
            if (_target.x < Transform.position.x)
                X = Multiplier.NEGATIVE;
            else if (_target.x > Transform.position.x)
                X = Multiplier.POSITIVE;
            else
                X = Multiplier.ZERO;
            base.Do();
        }

        public void ListenEntityReposition(Vector3 position)
        {
            if (_target.magnitude >= position.magnitude)
                return;
            _target = position;
        }

        public void ListenEntityCreation(Entity created)
        {
            if (created is Human)
                created.Repositioned += ListenEntityReposition;
        }

        public void ListenEntityDestruction(Entity destroyed)
        {
            if (destroyed is Human)
                destroyed.Repositioned -= ListenEntityReposition;
        }
    }
}