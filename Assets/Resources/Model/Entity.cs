using UnityEngine;

namespace Assets.Resources.Model
{
    public abstract class Entity
    {
        private Transform _transform;

        private Multiplier _x;
        private Multiplier _y;
        private Multiplier _z;

        private XYZValue _speed;

        public Transform Transform => _transform;

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

        public XYZValue Speed => _speed;

        public delegate void MoveEventHandler(Vector3 position);

        public event MoveEventHandler Moved;

        public Entity(Transform transform, Multiplier x, Multiplier y, Multiplier z, XYZValue speed)
        {
            _transform = transform;
            _x = x;
            _y = y;
            _z = z;
            _speed = speed;
        }

        public virtual void Move()
        {
            float mx = 0f;
            switch (X)
            {
                case Multiplier.ZERO:
                    break;
                case Multiplier.NEGATIVE:
                    mx = -1f;
                    break;
                case Multiplier.POSITIVE:
                    mx = 1f;
                    break;
            }

            float my = 0f;
            switch (Y)
            {
                case Multiplier.ZERO:
                    break;
                case Multiplier.NEGATIVE:
                    my = -1f;
                    break;
                case Multiplier.POSITIVE:
                    my = 1f;
                    break;
            }

            float mz = 0f;
            switch (Z)
            {
                case Multiplier.ZERO:
                    break;
                case Multiplier.NEGATIVE:
                    mz = -1f;
                    break;
                case Multiplier.POSITIVE:
                    mz = 1f;
                    break;
            }

            float x = mx * Speed.X;
            float y = my * Speed.Y;
            float z = mz * Speed.Z;

            _transform.Translate(Time.deltaTime * new Vector3(x, y, z));
            OnMoved();
        }

        private void OnMoved()
        {
            Moved?.Invoke(_transform.position);
        }
    }
}