using UnityEngine;

namespace Assets.Model
{
    public interface IMovable
    {
        XYZValue Speed { get; }
        Multiplier X { get; }
        Multiplier Y { get; }
        Multiplier Z { get; }

        void Move();

        delegate void MovableEventHandler(Vector3 position);
        event MovableEventHandler Moved;

        void OnMoved();
    }
}