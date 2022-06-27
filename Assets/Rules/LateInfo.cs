namespace Assets.Rules
{
    public sealed class LateInfo
    {
        private readonly IRule _late;

        public LateInfo(IRule late)
        {
            _late = late;
        }

        public IRule Late => _late;
    }
}