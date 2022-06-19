namespace Assets.Model
{
    public interface IUsable
    {
        delegate void UsableEventHandler(UsableInfo info);
        event UsableEventHandler Used;

        void Use();

        void OnUsed();
    }
}