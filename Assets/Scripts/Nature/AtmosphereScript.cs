using UnityEngine;
using Assets.Rules;
using Assets.Rules.Nature;

namespace Assets.Scripts.Nature
{
    public class AtmosphereScript : MonoBehaviour,
        IRuleScript
    {
        private IRule _atmosphere;

        public IRule Rule => _atmosphere;

        private void Awake()
        {
            _atmosphere = new Atmosphere(transform);
            _atmosphere.Awake();
        }

        private void Start()
        {
            _atmosphere.Start();
        }

        private void Update()
        {
            _atmosphere.Update();
        }
    }
}