using UnityEngine;
using Assets.Resources.Model.Belong;

namespace Assets.Resources.Components
{
    public class CakeComponent : MonoBehaviour
    {
        private Cake _cake;

        private void Awake()
        {
            _cake = new Cake(transform);
        }

        private void Update()
        {
            _cake.Do();
        }
    }
}