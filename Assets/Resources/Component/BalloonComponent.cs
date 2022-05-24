using UnityEngine;
using Assets.Resources.Model;

namespace Assets.Resources.Component
{
    public class BalloonComponent : MonoBehaviour
    {
        private Balloon _balloon;

        private void Awake()
        {
            _balloon = new Balloon(transform, Multiplier.POSITIVE, Multiplier.POSITIVE, Multiplier.ZERO, new XYZValue(0.23f, 0.23f, 0f));
        }

        private void Update()
        {
            _balloon.Move();
            _balloon.ConsumeTime();
        }
    }
}