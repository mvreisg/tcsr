using UnityEngine;
using Assets.Model.Nature;

namespace Assets.Components
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