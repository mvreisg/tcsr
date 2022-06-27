using System;
using UnityEngine;

namespace Assets.Rules
{
    /// <summary>
    ///     <para>A day.</para>
    /// </summary>
    public class Day : 
        IRule
    {
        public delegate void DayEventHandler(DayInfo info);
        public event DayEventHandler SecondPassed;

        public const float ONE_SECOND = 1f;

        public const float SECONDS_PER_MINUTE = 60f;
        public const float SECONDS_PER_HOUR = 60f * 60f;
        public const float SECONDS_PER_DAY = 60f * 60f * 24f;
        
        public const float MINUTES_PER_HOUR = 60f;
        public const float MINUTES_PER_DAY = 60f * 24f;

        public const float HOURS_PER_DAY = 24f;

        private readonly Transform _transform;

        private float _secondsElapsed;
        private float _delta;
        private float _multiplier;

        public Day(Transform transform)
        {
            _transform = transform;
            _multiplier = 0f;
        }

        public Day(Transform transform, int hour, int minute, int second, float multiplier) : this(transform)
        {
            _secondsElapsed = hour * SECONDS_PER_HOUR + minute * SECONDS_PER_MINUTE + second;
            _multiplier = multiplier;
        }

        public Transform Transform => _transform;

        private float Now
        {
            get
            {
                DateTime now = DateTime.Now;
                float hour = now.Hour;
                float minute = now.Minute;
                float second = now.Second;

                float hoursInSeconds = hour * SECONDS_PER_HOUR;
                float minutesInSeconds = minute * SECONDS_PER_MINUTE;
                float seconds = second;

                return hoursInSeconds + minutesInSeconds + seconds;
            }
        }

        public void Awake()
        {
            Application.focusChanged += ApplicationFocusChanged;   
        }

        public void Start()
        {
            OnSecondPassed(GetTime());
        }

        public void Update()
        {
            if (_multiplier > 0.0f)
                _delta += Time.deltaTime * _multiplier;
            else
                _delta += Time.deltaTime;

            if (_delta < ONE_SECOND)
                return;
            else
            {
                _secondsElapsed += _delta;
                _delta %= ONE_SECOND;
                OnSecondPassed(GetTime());
            }

            if (_secondsElapsed < SECONDS_PER_DAY)
                return;
            else // a day has passed
                _secondsElapsed %= SECONDS_PER_DAY;
        }

        // Class originals

        private DayInfo GetTime()
        {
            float totalSeconds = _secondsElapsed;
            float hour = totalSeconds / SECONDS_PER_HOUR;
            float minute = (totalSeconds % SECONDS_PER_HOUR) / SECONDS_PER_MINUTE;
            float second = (totalSeconds % SECONDS_PER_HOUR) % SECONDS_PER_MINUTE;
            return new DayInfo(hour, minute, second);
        }

        private void OnSecondPassed(DayInfo info)
        {
            SecondPassed?.Invoke(info);
        }

        private void ApplicationFocusChanged(bool hasFocus)
        {
            if (!hasFocus)
                return;
            _delta = 0f;
            _secondsElapsed = Now;
        }
    }
}