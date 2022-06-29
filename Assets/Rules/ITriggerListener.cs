namespace Assets.Rules
{
    public interface ITriggerListener
    {
        void ListenTriggerEntered(TriggerInfo info);

        void ListenTriggerExited(TriggerInfo info);
    }
}