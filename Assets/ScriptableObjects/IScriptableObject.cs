using UnityEngine;
using Assets.Model;

namespace Assets.ScriptableObjects
{
    public interface IScriptableObject
    {
        GameObject Prefab { get; }
    }
}