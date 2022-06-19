namespace Assets.Model
{
    public interface ISpawn
    {
        delegate void SpawnEventHandler(SpawnInfo info);
        event SpawnEventHandler Spawned;

        void Spawn();

        void OnSpawned(SpawnInfo info);
    }
}