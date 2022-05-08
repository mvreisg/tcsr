namespace Assets.Resources.Scripts.Creatures
{
    public interface IAggressiveCreature : ICreature
    {
        public bool CanMove { get; }

        public float Speed { get; }

        void MoveTowards();
    }
}
