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

        [SerializeField]
        private BalloonScriptableObject _balloonScriptableObject;

        public IEntity Entity => _earth;

        private float BalloonCooldown => Random.Range(0.23f, 1.23f);

        private float _balloonCooldown;

        private void Awake()
        {
            _earth = new Earth(transform);
            InstantiateBlu(new Vector3(0f, 2f, 0f));
            InstantiateBestmare(new Vector3(-7f, 2f, 0f));
            InstantiateBestmare(new Vector3(7f, 2f, 0f));
            _balloonCooldown = BalloonCooldown;
        }

        private void Update()
        {
            _earth.Exist();
            _balloonCooldown -= Time.deltaTime;
            if (_balloonCooldown < 0f)
            {
                _balloonCooldown = BalloonCooldown;
                InstantiateBalloon(new Vector3(Random.Range(-5f, 5f), 1f, 0f));
            }
        }

        private void InstantiateBlu(Vector3 position)
        {
            _earth.Instantiate(_humanScriptableObject, position);
        }

        private void InstantiateBestmare(Vector3 position)
        {
            _earth.Instantiate(_bestmareScriptableObject, position);
        }

        private void InstantiateBalloon(Vector3 position)
        {
            _earth.Instantiate(_balloonScriptableObject, position);
        }
    }
}