namespace Assets.Model
{
    public sealed class GenerationInfo
    {
        private readonly IModel _generated;

        public GenerationInfo(IModel generated)
        {
            _generated = generated;
        }

        public IModel Generated => _generated;
    }
}