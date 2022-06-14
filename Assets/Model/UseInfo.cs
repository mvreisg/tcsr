namespace Assets.Model
{
    public sealed class UseInfo
    {
        private readonly IUseable _used;

        public UseInfo(IUseable used)
        {
            _used = used;
        }

        public IUseable Used => _used;
    }
}