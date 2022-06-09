using UnityEngine;
using Assets.Model.Nature;

namespace Assets.Components
{
    public class SunComponent : MonoBehaviour
    {
        private Sun _sun;

        private void Awake()
        {
            _sun = new Sun(transform);
        }

        private void Update()
        {
            _sun.Do();
        }
    }
}