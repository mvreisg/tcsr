namespace Assets.Rules
{
    public interface IUsableListener
    {
        void ListenUsableWhileBeingUsed(UsableInfo info);

        void ListenUsableAfterUse(UsableInfo info);
    }
}