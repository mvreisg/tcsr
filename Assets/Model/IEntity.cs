using UnityEngine;

namespace Assets.Model
{
    /// <summary>
    ///     <para>Entity abstraction.</para>
    /// </summary>
    public interface IEntity
    {
        Transform Transform { get; }

        void Update();
    }
}