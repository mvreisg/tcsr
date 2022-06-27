using UnityEngine;

namespace Assets.Rules
{
    /// <summary>
    ///     <para>Rule for a script.</para>
    /// </summary>
    public interface IRule
    {
        Transform Transform { get; }

        void Awake();

        void Start();

        void Update();
    }
}