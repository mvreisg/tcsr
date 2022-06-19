using UnityEngine;

namespace Assets.Model
{
    public interface IMovable 
    {
        delegate void MovableEventHandler(MovementInfo info);
        event MovableEventHandler Moved;

        XYZValue Speed { get; }

        Multiplier Multiplier { get; }

        void Move();

        void OnMoved();
    }
}