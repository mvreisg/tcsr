using UnityEngine;

namespace Assets.Resources.Model.Bio
{
    public abstract class Animal : LivingBeing,
        ITransform,
        ISpriteRenderer
    {
        private readonly XYZValue _speed;
        private Multiplier _x;
        private Multiplier _y;
        private Multiplier _z;
        private readonly SpriteRenderer _spriteRenderer;

        public Animal(
            Transform transform, 
            XYZValue speed, 
            Multiplier x, 
            Multiplier y, 
            Multiplier z,
            Vector3 force) : base(transform, force)
        {
            _speed = speed;
            _x = x;
            _y = y;
            _z = z;
            _spriteRenderer = transform.GetComponent<SpriteRenderer>();
        }

        public XYZValue Speed => _speed;

        public Multiplier X
        {
            get => _x;
            set => _x = value;
        }

        public Multiplier Y
        {
            get => _y;
            set => _y = value;
        }

        public Multiplier Z
        {
            get => _z;
            set => _z = value;
        }

        public SpriteRenderer SpriteRenderer => _spriteRenderer;

        public void Move()
        {
            float x;
            float y;
            float z;

            switch (X)
            {
                default:
                    throw new UnityException($"unhandled state: {X}");
                case Multiplier.NEGATIVE:
                    x = -1f;
                    break;
                case Multiplier.ZERO:
                    x = 0f;
                    break;
                case Multiplier.POSITIVE:
                    x = 1f;
                    break;
            }

            switch (Y)
            {
                default:
                    throw new UnityException($"unhandled state: {Y}");
                case Multiplier.NEGATIVE:
                    y = -1f;
                    break;
                case Multiplier.ZERO:
                    y = 0f;
                    break;
                case Multiplier.POSITIVE:
                    y = 1f;
                    break;
            }

            switch (Z)
            {
                default:
                    throw new UnityException($"unhandled state: {Z}");
                case Multiplier.NEGATIVE:
                    z = -1f;
                    break;
                case Multiplier.ZERO:
                    z = 0f;
                    break;
                case Multiplier.POSITIVE:
                    z = 1f;
                    break;
            }

            float sx = x * Speed.X;
            float sy = y * Speed.Y;
            float sz = z * Speed.Z;

            Transform.Translate(Time.deltaTime * new Vector3(sx, sy, sz));
        }

        public override void Do()
        {
            base.Do();
            Move();
        }
    }
}