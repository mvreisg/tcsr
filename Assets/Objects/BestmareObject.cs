using UnityEngine;

namespace Assets.Objects
{
    [CreateAssetMenu(fileName = "Bestmare", menuName = "ScriptableObject/Bestmare", order = 1)]
    public class BestmareObject : ScriptableObject,
        IObject
    {
        [SerializeField]
        private GameObject _prefab;

        public GameObject Prefab => _prefab;
    }
}