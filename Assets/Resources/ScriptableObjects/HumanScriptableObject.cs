using UnityEngine;

namespace Assets.Resources.ScriptableObjects
{
    [CreateAssetMenu(fileName = "HumanScriptableObject", menuName = "ScriptableObject/Human", order = 0)]
    public class HumanScriptableObject : ScriptableObject
    {
        [SerializeField]
        private GameObject _prefab;

        public GameObject Prefab => _prefab;
    }
}