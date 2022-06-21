using System;
using UnityEngine;

namespace Assets.Model.Belong
{
    /// <summary>
    ///     <para>Our way to measure time.</para>
    /// </summary>
    public class Clock : 
        IModel
    {
        public delegate void ClockEventHandler(ClockInfo info);
        public event ClockEventHandler Ticked;

        public const float ONE_SECOND = 1f;

        public const float SECONDS_PER_MINUTE = 60f;
        public const float SECONDS_PER_HOUR = 60f * 60f;
        public const float SECONDS_PER_DAY = 60f * 60f * 24f;
        
        public const float MINUTES_PER_HOUR = 60f;
        public const float MINUTES_PER_DAY = 60f * 24f;

        public const float HOURS_PER_DAY = 24f;

        private readonly Transform _transform;

        private float _day;
        private float _delta;

        public Clock(Transform transform)
        {
            _transform = transform;
        }

        public Clock(Transform transform, int hour, int minute, int second) : this(transform)
        {
            _day = hour * SECONDS_PER_HOUR + minute * SECONDS_PER_MINUTE + second;
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
            OnTicked(GetTime());
        }

        public void Update()
        {
            _delta += Time.deltaTime * 5000f;
            if (_delta < ONE_SECOND)
                return;
            else
            {
                _day += _delta;
                _delta %= ONE_SECOND;
                OnTicked(GetTime());
            }

            if (_day < SECONDS_PER_DAY)
                return;
            else // a day has passed
                _day %= SECONDS_PER_DAY;
        }

        // Class originals

        private ClockInfo GetTime()
        {
            float totalSeconds = _day;
            float hour = totalSeconds / SECONDS_PER_HOUR;
            float minute = (totalSeconds % SECONDS_PER_HOUR) / SECONDS_PER_MINUTE;
            float second = (totalSeconds % SECONDS_PER_HOUR) % SECONDS_PER_MINUTE;
            return new ClockInfo(hour, minute, second);
        }

        private void OnTicked(ClockInfo info)
        {
            Ticked?.Invoke(info);
        }

        private void ApplicationFocusChanged(bool hasFocus)
        {
            if (!hasFocus)
                return;
            _delta = 0f;
            _day = Now;
        }
    }
}