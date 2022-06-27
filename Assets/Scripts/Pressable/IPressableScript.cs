namespace Assets.Scripts.Pressable
{
    public interface IPressableScript
    {
        delegate void StateEventHandler();
        event StateEventHandler Down;
        event StateEventHandler Up;
    }
}