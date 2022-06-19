namespace Assets.Model
{
    public sealed class UsableInfo
    {
        private readonly IUsable _used;

        public UsableInfo(IUsable used)
        {
            _used = used;
        }

        public IUsable Used => _used;
    }
}
