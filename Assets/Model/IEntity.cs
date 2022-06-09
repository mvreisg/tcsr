using UnityEngine;

namespace Assets.Model
{
    public interface IEntity
    {
        delegate void PositionEventHandler(Vector3 position);
        event PositionEventHandler Repositioned;

        delegate void RecycleEventHandler(Entity entity);
        event RecycleEventHandler Recycled;
    }
}