namespace Assets.Rules
{
    public sealed class UseInfo
    {
        private readonly IUse _user;

        public UseInfo(IUse user)
        {
            _user = user;
        }

        public IUse User => _user;
    }
}