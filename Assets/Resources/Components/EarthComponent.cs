using UnityEngine;
using Assets.Resources.Model.Nature;
using Assets.Resources.ScriptableObjects;

namespace Assets.Resources.Components
{
    public class EarthComponent : MonoBehaviour
    {
        private Earth _earth;

        [SerializeField]
        private BluScriptableObject _bluScriptableObject;

        [SerializeField]
        private BestmareScriptableObject _bestmareScriptableObject;

        private void Awake()
        {
            _earth = new Earth(transform);
            CreateBlu(new Vector3(0f, 2f, 0f));
            CreateBestmare(new Vector3(-3f, 2f, 0f));
        }

        private void Start()
        {
            
        }

        private void Update()
        {
            _earth.Do();
        }

        private void CreateBlu(Vector3 position)
        {
            _earth.Conceive(
                _earth.Instantiate(
                    _bluScriptableObject, 
                    position
                ).GetComponent<BluComponent>().Human
            );
        }

        private void CreateBestmare(Vector3 position)
        {
            _earth.Conceive(
                _earth.Instantiate(
                    _bestmareScriptableObject,
                    position
                ).GetComponent<BestmareComponent>().Bestmare
            );
        }
    }
}