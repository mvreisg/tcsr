namespace Assets.Model
{
    public sealed class PickInfo
    {
        private readonly IEntity _picker;
        private readonly IEntity _picked;

        public PickInfo(IEntity picker, IEntity picked)
        {
            _picker = picker;
            _picked = picked;
        }

        public IEntity Picker => _picker;

        public IEntity Picked => _picked;
    }
}