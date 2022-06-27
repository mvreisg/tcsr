using UnityEngine;

namespace Assets.Rules
{
    public interface IMovable 
    {
        delegate void MovableEventHandler(MovementInfo info);
        event MovableEventHandler Moved;

        XYZValue Speed { get; }

        Orientation Orientation { get; }

        void Move();

        void OnMoved();
    }
}