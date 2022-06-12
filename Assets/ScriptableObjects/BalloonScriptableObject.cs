using UnityEngine;

namespace Assets.ScriptableObjects
{
    [CreateAssetMenu(fileName = "BalloonScriptableObject", menuName = "ScriptableObject/Balloon", order = 0)]
    public class BalloonScriptableObject : ScriptableObject,
        IScriptableObject
    {
        [SerializeField]
        private GameObject _prefab;

        public GameObject Prefab => _prefab;
    }
}