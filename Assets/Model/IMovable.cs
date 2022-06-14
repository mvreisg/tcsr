namespace Assets.Model
{
    public interface IMovable
    {
        XYZValue Speed { get; }
        Multiplier X { get; }
        Multiplier Y { get; }
        Multiplier Z { get; }

        void Move();

        delegate void MovableEventHandler(MovementInfo movementInfo);
        event MovableEventHandler Moved;

        void OnMoved();
    }
}