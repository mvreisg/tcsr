using UnityEngine;

namespace Assets.ScriptableObjects
{
    public interface IScriptableObject
    {
        GameObject Prefab { get; }
    }
}