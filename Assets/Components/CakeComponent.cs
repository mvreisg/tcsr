using UnityEngine;
using Assets.Model.Belong;

namespace Assets.Components
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