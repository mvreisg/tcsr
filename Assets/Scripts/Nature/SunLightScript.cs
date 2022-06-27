using UnityEngine;
using Assets.Rules;
using Assets.Rules.Nature;

namespace Assets.Scripts.Nature
{
    public class SunLightScript : MonoBehaviour,
        IRuleScript
    {
        private SunLight _sunLight;

        public IRule Rule => _sunLight;

        private void Awake()
        {
            _sunLight = new SunLight(transform);
            _sunLight.Awake();
        }

        private void Start()
        {
            _sunLight.Start();
        }

        private void Update()
        {
            _sunLight.Update();
        }
    }
}