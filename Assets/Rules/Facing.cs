namespace Assets.Rules
{
    public class Facing
    {
        private Flag _x;

        public Facing(Flag x)
        {
            _x = x;
        }

        public Flag X
        {
            get => _x;
            set => _x = value;
        }
    }
}