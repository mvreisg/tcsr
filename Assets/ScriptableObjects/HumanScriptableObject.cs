using UnityEngine;

namespace Assets.ScriptableObjects
{
    [CreateAssetMenu(fileName = "HumanScriptableObject", menuName = "ScriptableObject/Human", order = 0)]
    public class HumanScriptableObject : ScriptableObject,
        IScriptableObject
    {
        [SerializeField]
        private GameObject _prefab;

        public GameObject Prefab => _prefab;
    }
}