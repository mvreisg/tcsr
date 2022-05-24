using UnityEngine;
using Assets.Resources.Model;

namespace Assets.Resources.Component
{
    public class CloudComponent : MonoBehaviour
    {
        private Cloud _cloud;

        private void Awake()
        {
            
            _cloud = new Cloud(transform, Multiplier.POSITIVE, Multiplier.ZERO, Multiplier.ZERO, new XYZValue(0.23f, 0f, 0f), FindObjectOfType<Camera>());
        }

        private void Update()
        {
            _cloud.Move();
            _cloud.Disappear();
        }
    }
}