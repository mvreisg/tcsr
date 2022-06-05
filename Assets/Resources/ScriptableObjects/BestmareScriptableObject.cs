using UnityEngine;

namespace Assets.Resources.ScriptableObjects
{
    [CreateAssetMenu(fileName = "BestmareScriptableObject", menuName = "ScriptableObject/Bestmare", order = 1)]
    public class BestmareScriptableObject : ScriptableObject
    {
        [SerializeField]
        private GameObject _bestmarePrefab;

        public GameObject BestmarePrefab => _bestmarePrefab;
    }
}