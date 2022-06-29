using UnityEngine;
using Assets.Rules;
using Assets.Rules.Nature;

namespace Assets.Scripts.Nature
{
    public class EarthScript : MonoBehaviour,
        IRuleScript
    {
        private IRule _earth;

        public IRule Rule => _earth;

        private void Awake()
        {
            _earth = new Earth(transform);
            _earth.Awake();
        }

        private void Start()
        {
            _earth.Start();
        }

        private void Update()
        {
            _earth.Update();
        }
    }
}