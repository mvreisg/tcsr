namespace Assets.Rules
{
    public sealed class PickInfo
    {
        private readonly IUser _picker;
        private readonly IUsable _picked;

        public PickInfo(IUser picker, IUsable picked)
        {
            _picker = picker;
            _picked = picked;
        }

        public IUser Picker => _picker;

        public IUsable Picked => _picked;
    }
}