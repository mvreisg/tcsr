namespace Assets.Model
{
    public sealed class SpawnInfo
    {
        private readonly IModel _spawned;

        public SpawnInfo(IModel spawned)
        {
            _spawned = spawned;
        }

        public IModel Spawned => _spawned;
    }
}