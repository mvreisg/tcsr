using UnityEngine;
using Assets.Resources.Model.Nature;

namespace Assets.Resources.Component
{
    public class EarthComponent : MonoBehaviour
    {
        private Earth _earth;

        private void Awake()
        {
            _earth = new Earth(transform);
        }

        private void Update()
        {
            _earth.Do();
        }
    }
}