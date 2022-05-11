namespace Assets.Resources.Scripts.Creatures
{
    public interface IPersecutorCreature
    {
        bool CanPersecute { get; }

        void Persecute();
    }
}
