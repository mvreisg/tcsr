using UnityEngine;
using Assets.Resources.Model.Controllers;

namespace Assets.Resources.Model.Bio
{
    public abstract class LivingBeing : Entity,
        ITransform,
        ISpriteRenderer,
        IRigidbody2D
    {
        private readonly XYZValue _speed;
        private Multiplier _x;
        private Multiplier _y;
        private Multiplier _z;
        private readonly SpriteRenderer _spriteRenderer;
        private Vector3 _force;
        private readonly Rigidbody2D _rigidbody2D;

        public LivingBeing(
            Transform transform,
            XYZValue speed,
            Multiplier x,
            Multiplier y,
            Multiplier z,
            Vector3 force) : 
            base(transform)
        {
            _speed = speed;
            _x = x;
            _y = y;
            _z = z;
            _spriteRenderer = transform.GetComponent<SpriteRenderer>();
            _force = force;
            _rigidbody2D = transform.GetComponent<Rigidbody2D>();
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

        public Vector3 Force => _force;

        public Rigidbody2D Rigidbody2D => _rigidbody2D;

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
            OnRepositioned(Transform.position);
        }

        public void Gravity()
        {
            Rigidbody2D.AddForce(Force);
        }

        public override void Do()
        {
            Move();
            Gravity();
        }

        public void ListenPlayerAction(Action action)
        {
            switch (action)
            {
                default:
                    throw new UnityException($"unhandled state: {action}");
                case Action.IDLE:
                    break;
                case Action.STOP:
                    Stop();
                    break;
                case Action.BACK:
                    TurnBack();
                    break;
                case Action.FORWARD:
                    TurnForward();
                    break;
                case Action.USE:
                    break;
            }
        }

        private void Stop()
        {
            X = Multiplier.ZERO;
        }

        private void TurnBack()
        {
            X = Multiplier.NEGATIVE;
            SpriteRenderer.flipX = true;
        }

        private void TurnForward()
        {
            X = Multiplier.POSITIVE;
            SpriteRenderer.flipX = false;
        }
    }
}