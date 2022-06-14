using UnityEngine;
using Assets.Model;
using Assets.Model.Nature;
using Assets.ScriptableObjects;

namespace Assets.Components.Entity
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
            InstantiateBlu(new Vector3(0f, 2f, 0f));
            InstantiateBestmare(new Vector3(-7f, 2f, 0f));
            InstantiateBestmare(new Vector3(7f, 2f, 0f));
        }

        private void Start()
        {
            _earth.AcknowledgeExistants();
        }

        private void Update()
        {
            _earth.Update();
        }

        private void InstantiateBlu(Vector3 position)
        {
            _earth.Instantiate(_humanScriptableObject, position);
        }

        private void InstantiateBestmare(Vector3 position)
        {
            _earth.Instantiate(_bestmareScriptableObject, position);
        }
    }
}