using UnityEngine;

namespace Assets.Model
{
    public abstract class Entity :
        IEntity, 
        ITransform
    {
        public event IEntity.PositionEventHandler Repositioned;
        public event IEntity.RecycleEventHandler Recycled;

        private readonly Transform _transform;
        private XYZValue _speed;
        private Multiplier _x;
        private Multiplier _y;
        private Multiplier _z;

        public Entity(Transform transform)
        {
            _transform = transform;
            _speed = XYZValue.ZERO;
            _x = Multiplier.ZERO;
            _y = Multiplier.ZERO;
            _z = Multiplier.ZERO;
        }

        public Transform Transform => _transform;

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

        public virtual void Move()
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

        public abstract void Do();

        public void OnRepositioned(Vector3 position)
        {
            Repositioned?.Invoke(position);
        }

        public void OnRecycled()
        {
            Recycled?.Invoke(this);
            Object.Destroy(Transform.gameObject);
        }
    }
}