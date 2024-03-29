using UnityEngine;

namespace Assets.Data
{
    [CreateAssetMenu(fileName = "Balloon", menuName = "ScriptableObject/Balloon", order = 0)]
    public class BalloonObject : ScriptableObject,
        IObject
    {
        [SerializeField]
        private GameObject _prefab;

        public GameObject Prefab => _prefab;
    }
}