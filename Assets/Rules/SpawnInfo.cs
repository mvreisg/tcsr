namespace Assets.Rules
{
    public sealed class SpawnInfo
    {
        private readonly IRule _spawned;

        public SpawnInfo(IRule spawned)
        {
            _spawned = spawned;
        }

        public IRule Spawned => _spawned;
    }
}