using UnityEngine;
using Assets.Resources.Model;
using Assets.Resources.Model.Bio;

namespace Assets.Resources.Components
{
    public class BestmareComponent : MonoBehaviour
    {
        private Bestmare _bestmare;

        public Bestmare Bestmare => _bestmare;

        private void Awake()
        {
            _bestmare = new Bestmare(
                transform,
                new XYZValue(1f, 0f, 0f),
                Multiplier.ZERO,
                Multiplier.ZERO,
                Multiplier.ZERO,
                new Vector3(0f, 0f, 0f)
            );
        }

        private void Update()
        {
            _bestmare.Do();
        }
    }
}