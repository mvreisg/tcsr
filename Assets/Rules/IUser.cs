namespace Assets.Rules
{
    public interface IUser
    {
        delegate void UserEventHandler(UseInfo info);
        event UserEventHandler Used;

        void Use();

        void OnUsed();
    }
}