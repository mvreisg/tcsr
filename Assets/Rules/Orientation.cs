namespace Assets.Rules
{
    public class Orientation
    {
        private Flag _x;
        private Flag _y;
        private Flag _z;

        public Orientation()
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