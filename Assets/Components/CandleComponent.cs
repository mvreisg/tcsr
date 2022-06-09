using UnityEngine;
using Assets.Model;
using Assets.Model.Belong;

namespace Assets.Components
{
    public class CandleComponent : MonoBehaviour,
        IEntityComponent
    {
        private Candle _candle;

        public IEntity Entity => _candle;

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