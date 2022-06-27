using UnityEngine;

namespace Assets.Objects
{
    [CreateAssetMenu(fileName = "Blu", menuName = "ScriptableObject/Blu", order = 0)]
    public class BluObject : ScriptableObject,
        IObject
    {
        [SerializeField]
        private GameObject _prefab;

        public GameObject Prefab => _prefab;
    }
}