namespace Assets.Model
{
    public sealed class LateInfo
    {
        private readonly IModel _late;

        public LateInfo(IModel late)
        {
            _late = late;
        }

        public IModel Late => _late;
    }
}