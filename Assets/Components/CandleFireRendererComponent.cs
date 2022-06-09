using UnityEngine;
using Assets.Model.Nature;

namespace Assets.Components
{
    public class CandleFireRendererComponent : MonoBehaviour
    {
        private Fire _fire;

        private void Awake()
        {
            _fire = new Fire(transform);
        }

        private void Update()
        {
            _fire.Do();
        }
    }
}