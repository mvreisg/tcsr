using UnityEngine;
using Assets.Model;
using Assets.Model.Nature;
using Assets.ScriptableObjects;

namespace Assets.Components
{
    public class EarthComponent : MonoBehaviour,
        IEntityComponent
    {
        private Earth _earth;

        [SerializeField]
        private HumanScriptableObject _humanScriptableObject;

        [SerializeField]
        private BestmareScriptableObject _bestmareScriptableObject;

        public IEntity Entity => _earth;

        private void Awake()
        {
            _earth = new Earth(transform);
            CreateBlu(new Vector3(0f, 2f, 0f));
            CreateBestmare(new Vector3(-6f, 2f, 0f));
            CreateBestmare(new Vector3(6f, 2f, 0f));
        }

        private void Update()
        {
            _earth.Do();
        }

        private void CreateBlu(Vector3 position)
        {
            _earth.Instantiate(_humanScriptableObject, position);
        }

        private void CreateBestmare(Vector3 position)
        {
            _earth.Instantiate(_bestmareScriptableObject, position);
        }
    }
}