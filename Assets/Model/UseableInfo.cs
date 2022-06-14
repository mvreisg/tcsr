namespace Assets.Model
{
    public sealed class UseableInfo
    {
        private readonly IUseable _useable;

        public UseableInfo(IUseable useable)
        {
            _useable = useable;
        }

        public IUseable Useable => _useable;
    }
}
