using UnityEngine;
using Assets.Rules;
using Assets.Rules.Nature;

namespace Assets.Scripts.Nature
{
    public class SunScript : MonoBehaviour,
        IRuleScript
    {
        private IRule _sun;

        [SerializeField]
        private float _low;

        [SerializeField]
        private float _peak;

        public IRule Rule => _sun;

        private void Awake()
        {
            _sun = new Sun(transform, _low, _peak);
            _sun.Awake();
        }

        private void Start()
        {
            _sun.Start();
        }

        private void Update()
        {
            _sun.Update();
        }
    }
}