using UnityEngine;

namespace Assets.Model
{
    /// <summary>
    ///     <para>Model of a component.</para>
    /// </summary>
    public interface IModel
    {
        Transform Transform { get; }

        void Awake();

        void Start();

        void Update();
    }
}