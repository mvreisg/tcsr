namespace Assets.Model
{
    public sealed class SpawnInfo
    {
        private readonly IEntity _spawned;

        public SpawnInfo(IEntity spawned)
        {
            _spawned = spawned;
        }

        public IEntity Spawned => _spawned;
    }
}