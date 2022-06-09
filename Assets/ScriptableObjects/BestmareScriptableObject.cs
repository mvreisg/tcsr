using UnityEngine;

namespace Assets.ScriptableObjects
{
    [CreateAssetMenu(fileName = "BestmareScriptableObject", menuName = "ScriptableObject/Bestmare", order = 1)]
    public class BestmareScriptableObject : ScriptableObject,
        IScriptableObject
    {
        [SerializeField]
        private GameObject _prefab;

        public GameObject Prefab => _prefab;
    }
}