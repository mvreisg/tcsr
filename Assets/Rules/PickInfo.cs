namespace Assets.Rules
{
    public sealed class PickInfo
    {
        private readonly IUse _picker;
        private readonly IUsable _picked;

        public PickInfo(IUse picker, IUsable picked)
        {
            _picker = picker;
            _picked = picked;
        }

        public IUse Picker => _picker;

        public IUsable Picked => _picked;
    }
}