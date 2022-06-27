using Assets.Rules.Items;

namespace Assets.Rules
{
    public sealed class UseInfo
    {
        private readonly IUser _user;
        private readonly Item _type;

        public UseInfo(IUser user, Item type)
        {
            _user = user;
            _type = type;
        }

        public IUser User => _user;

        public Item Type => _type;
    }
}