using UnityEngine;

namespace Assets.Resources.Model.Nature
{
    public class Sun : Entity, ILight
    {
        private readonly Light _light;
        private float _hours;
        private float _minutes;
        private float _seconds;

        public Sun(Transform transform, float hours, float minutes, float seconds) : base(transform)
        {
            _light = transform.GetComponent<Light>();
            _hours = hours;
            _minutes = minutes;
            _seconds = seconds;
        }

        public Light Light => _light;

        public override void Do()
        {
            _seconds += Time.deltaTime;
            if (_seconds >= 60f)
            {
                _seconds %= 60f;
                _minutes += 1f;
            }
            if (_minutes >= 60f)
            {
                _minutes %= 60f;
                _hours += 1f;
            }
            if (_hours >= 24f)
            {
                _seconds = (_hours % 24f) / (60f * 60f);
                _minutes = (_hours % 24f) / 60f;
                _hours %= 24f;
            }
            Debug.Log("Sun...");
        }
    }
}