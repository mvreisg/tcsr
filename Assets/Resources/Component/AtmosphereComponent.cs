using UnityEngine;
using Assets.Resources.Model.Nature;

namespace Assets.Resources.Component
{
    public class AtmosphereComponent : MonoBehaviour
    {
        private Atmosphere _atmosphere;

        private void Awake()
        {
            _atmosphere = new Atmosphere(transform);
        }

        private void Update()
        {
            _atmosphere.Do();
        }
    }
}