using UnityEngine;

namespace Assets.Model
{
    /// <summary>
    ///     <para>Entity interface.</para>
    /// </summary>
    public interface IEntity
    {
        Transform Transform { get; }

        void Exist();
    }
}