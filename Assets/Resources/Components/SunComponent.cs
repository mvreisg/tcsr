using UnityEngine;
using Assets.Resources.Model;
using Assets.Resources.Model.Nature;

namespace Assets.Resources.Components
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