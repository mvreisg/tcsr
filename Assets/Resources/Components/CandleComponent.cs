using UnityEngine;
using Assets.Resources.Model.Belong;

namespace Assets.Resources.Components
{
    public class CandleComponent : MonoBehaviour
    {
        private Candle _candle;

        private void Awake()
        {
            _candle = new Candle(transform);
        }

        private void Update()
        {
            _candle.Do();
        }
    }
}