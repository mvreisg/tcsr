using UnityEngine;
using Assets.Rules;
using Assets.Rules.Nature;

namespace Assets.Scripts.Nature
{
    public class AtmosphereScript : MonoBehaviour,
        IRuleScript
    {
        private Atmosphere _atmosphere;

        public IRule Rule => _atmosphere;

        private void Awake()
        {
            _atmosphere = new Atmosphere(transform);
        }

        private void Update()
        {
            _atmosphere.Update();
        }
    }
}