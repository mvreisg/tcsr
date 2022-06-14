using Assets.Components.Entity;
using Assets.ScriptableObjects;

namespace Assets.Model
{
    public interface ISpawn
    {
        delegate void SpawnEventHandler(SpawnInfo info);
        event SpawnEventHandler Spawned;

        void Start(IEntityComponent earthComponent);

        void Spawn(IScriptableObject ballonScriptableObject);

        void OnSpawned(SpawnInfo info);
    }
}