using UnityEngine;

namespace Assets.Resources.Components
{
    public interface IMovable
    {
        enum X
        {
            ZERO,
            NEGATIVE,
            POSITIVE
        }
        enum Y
        {
            ZERO,
            NEGATIVE,
            POSITIVE
        }
        enum Z
        {
            ZERO,
            NEGATIVE,
            POSITIVE
        }
        delegate void MovableEventHandler(Vector3 position);
        event MovableEventHandler Moved;
        bool CanMoveX { get; }
        bool CanMoveY { get; }
        bool CanMoveZ { get; }
        X IsX { get; }
        Y IsY { get; }
        Z IsZ { get; }
        float SpeedX { get; }
        float SpeedY { get; }
        float SpeedZ { get; }
    }
}