using UnityEngine;

namespace Assets.Resources.ScriptableObjects
{
    [CreateAssetMenu(fileName = "BluScriptableObject", menuName = "ScriptableObject/Blu", order = 0)]
    public class BluScriptableObject : ScriptableObject
    {
        [SerializeField]
        private GameObject _bluPrefab;

        public GameObject BluPrefab => _bluPrefab;
    }
}