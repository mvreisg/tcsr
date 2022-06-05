using UnityEngine;
using Assets.Resources.Model.Nature;

namespace Assets.Resources.Components
{
    public class SunComponent : MonoBehaviour
    {
        private Sun _sun;

        private void Awake()
        {
            _sun = new Sun(transform, 0f, 0f, 0f);
        }

        private void Update()
        {
            _sun.Do();
        }
    }
}