namespace Assets.Components
{
    public interface IPressableComponent
    {
        delegate void StateEventHandler();
        event StateEventHandler Down;
        event StateEventHandler Up;
    }
}