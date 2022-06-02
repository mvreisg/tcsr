using UnityEngine;

namespace Assets.Resources.Model.Existance
{
    public class Day : Entity
    {
        private float _days;
        private float _hours;
        private float _minutes;
        private float _seconds;

        public float Days => _days;
        public float Seconds => _seconds;
        public float Minutes => _minutes;
        public float Hours => _hours;

        public Day(Transform transform, float days, float hours, float minutes, float seconds) : base(transform)
        {
            _days = days;
            _hours = hours;
            _minutes = minutes;
            _seconds = seconds;
        }

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
                _days += 1f; 
            }
            if (_days >= 1f)
            {
                _seconds = (((_days % 1f) % 24f) / 60f) / 60f;
                _minutes = ((_days % 1f) % 24f) / 60f;
                _hours = (_days % 1f) / 24f;
                _days %= _days;
            }
        }
    }
}