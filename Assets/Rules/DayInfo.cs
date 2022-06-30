using System;
using UnityEngine;

namespace Assets.Rules
{
    [Serializable]
    public sealed class DayInfo
    {
        [SerializeField]
        private float _hour;

        [SerializeField]
        private float _minute;

        [SerializeField]
        private float _second;

        public DayInfo(float hour, float minute, float second)
        {
            _hour = hour;
            _minute = minute;
            _second = second;
        }

        public float Hour => _hour;

        public float Minute => _minute;

        public float Second => _second;

        public int RoundedDay
        {
            get
            {
                return
                    (int)_hour * (int)Day.SECONDS_PER_HOUR +
                    (int)_minute * (int)Day.SECONDS_PER_MINUTE +
                    (int)_second;
            }
        }
    }
}