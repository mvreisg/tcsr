using UnityEngine;

namespace Assets.ScriptableObjects
{
    [CreateAssetMenu(fileName = "BluScriptableObject", menuName = "ScriptableObject/Blu", order = 0)]
    public class BluScriptableObject : ScriptableObject,
        IScriptableObject
    {
        [SerializeField]
        private GameObject _prefab;

        public GameObject Prefab => _prefab;
    }
}