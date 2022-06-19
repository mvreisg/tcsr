namespace Assets.Model
{
    public sealed class UserInfo
    {
        private readonly IUser _user;
        private readonly IUsable _used;

        public UserInfo(IUser user, IUsable used)
        {
            _user = user;
            _used = used;
        }

        public IUser User => _user;

        public IUsable Used => _used;
    }
}