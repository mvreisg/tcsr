namespace Assets.Rules
{
    public class Facing
    {
        private Flags _x;

        public Facing(Flags x)
        {
            _x = x;
        }

        public Flags X
        {
            get => _x;
            set => _x = value;
        }
    }
}