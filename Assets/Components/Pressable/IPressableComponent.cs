namespace Assets.Components.Pressable
{
    public interface IPressableComponent
    {
        delegate void StateEventHandler();
        event StateEventHandler Down;
        event StateEventHandler Up;
    }
}