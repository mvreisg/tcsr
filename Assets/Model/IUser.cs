namespace Assets.Model
{
    public interface IUser
    {
        delegate void UserEventHandler(UserInfo info);
        event UserEventHandler Used;

        void Use();

        void OnUsed();
    }
}