namespace Assets.Rules
{
    public class Orientation
    {
        private Flags _x;
        private Flags _y;
        private Flags _z;

        public Orientation()
        {
            _x = Flags.ZERO;
            _y = Flags.ZERO;
            _z = Flags.ZERO;
        }

        public Flags X
        {
            get => _x;
            set => _x = value;
        }

        public Flags Y
        {
            get => _y;
            set => _y = value;
        }

        public Flags Z
        {
            get => _z;
            set => _z = value;
        }
    }
}