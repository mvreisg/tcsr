namespace Assets.Model
{
    public sealed class Multiplier
    {
        private Flag _x;
        private Flag _y;
        private Flag _z;

        public Multiplier()
        {
            _x = Flag.ZERO;
            _y = Flag.ZERO;
            _z = Flag.ZERO;
        }

        public Flag X
        {
            get => _x;
            set => _x = value;
        }

        public Flag Y
        {
            get => _y;
            set => _y = value;
        }

        public Flag Z
        {
            get => _z;
            set => _z = value;
        }
    }
}