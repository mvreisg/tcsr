using UnityEngine;
using Assets.Resources.Model;

namespace Assets.Resources.Component
{
    public class SunComponent : MonoBehaviour
    {
        private Sun _light;

        private void Awake()
        {
            _light = new Sun(transform, FindObjectOfType<Light>());
        }

        private void Update()
        {
            _light.UpdateIntensity();
        }
    }
}