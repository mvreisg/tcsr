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
        public const float ONE_MINUTE = 1f;
        public const float ONE_HOUR = 1f;
        public const float ONE_DAY = 1f;

        public const float ONE_MINUTE_IN_SECONDS = ONE_MINUTE * 60f;
        
        public const float ONE_HOUR_IN_SECONDS = ONE_SECOND * 3600f;
        public const float ONE_HOUR_IN_MINUTES = ONE_MINUTE * 60f;

        public const float ONE_DAY_IN_SECONDS = ONE_SECOND * 3600f * 24f;
        public const float ONE_DAY_IN_MINUTES = ONE_MINUTE * 60f * 24f;
        public const float ONE_DAY_IN_HOURS = ONE_HOUR * 24f;

        private readonly Transform _transform;

        private float _dayInSeconds;
        private float _deltaTime;
        private bool _focused;

        public Clock(Transform transform)
        {
            _transform = transform;
            _focused = true;
            _dayInSeconds = TodayInSeconds;
        }

        public Transform Transform => _transform;

        private float TodayInSeconds
        {
            get
            {
                DateTime now = DateTime.Now;
                float hour = now.Hour;
                float minute = now.Minute;
                float second = now.Second;

                float hoursInSeconds = hour * ONE_HOUR_IN_SECONDS;
                float minutesInSeconds = minute * ONE_MINUTE_IN_SECONDS;
                float seconds = second;

                return hoursInSeconds + minutesInSeconds + seconds;
            }
        }

        private float Hour
        {
            get
            {
                float hours = _dayInSeconds / ONE_HOUR_IN_SECONDS;
                float point = _dayInSeconds % ONE_HOUR_IN_SECONDS;
                return hours + point;
            }
        }

        private float Minute
        {
            get
            {
                float minutes = Hour / ONE_MINUTE_IN_SECONDS;
                float point = Hour % ONE_MINUTE_IN_SECONDS;
                return minutes + point;
            }
        }

        private float Second
        {
            get
            {
                float seconds = Minute / 60f;
                float point = Minute % 60f;
                return seconds + point;
            }
        }

        public void Awake()
        {
            Application.focusChanged += ApplicationFocusChanged;
            Measure();
        }

        public void Start()
        {
            Measure();
        }

        public void Update()
        {
            Measure();
        }

        private void Measure()
        {
            if (!_focused)
                return;

            _deltaTime += Time.deltaTime;
            if (_deltaTime < ONE_SECOND)
                return;
            else
            {
                _dayInSeconds += _deltaTime;
                _deltaTime %= ONE_SECOND;
                OnTicked(Hour, Minute, Second);
            }

            if (_dayInSeconds < ONE_DAY_IN_SECONDS)
                return;

            _dayInSeconds %= ONE_DAY_IN_SECONDS;
        }

        private void OnTicked(float hour, float minute, float second)
        {
            OnTicked(new ClockInfo(hour, minute, second));
        }

        private void OnTicked(ClockInfo info)
        {
            Ticked?.Invoke(info);
        }

        private void ApplicationFocusChanged(bool hasFocus)
        {
            _focused = hasFocus;
            _deltaTime = ONE_SECOND;
            _dayInSeconds = TodayInSeconds;
        }
    }
}