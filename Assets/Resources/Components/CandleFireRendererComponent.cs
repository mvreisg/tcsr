using UnityEngine;
using Assets.Resources.Model.Nature;

namespace Assets.Resources.Components
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