using System;
using UnityEngine;

namespace Assets.Model.Belong
{
    public class Clock : 
        IEntity
    {
        public delegate void ClockEventHandler(ClockInfo info);
        public event ClockEventHandler Ticked;

        public const float ONE_SECOND = 1f;
        public const float ONE_MINUTE = ONE_SECOND * 60f;
        public const float ONE_HOUR = ONE_MINUTE * 60f;

        private readonly Transform _transform;

        private float _elapsed;

        public Clock(Transform transform)
        {
            _transform = transform;
            Application.focusChanged += ApplicationFocusChanged;
        }

        public Transform Transform => _transform;

        public DateTime Now => DateTime.Now;

        public void Update()
        {
            Tick();
        }

        public override string ToString()
        {
            return string.Format("{0}:{1}:{2}", Now.Hour, Now.Minute, Now.Second);
        }

        private void Tick()
        {
            _elapsed += Time.deltaTime;
            if (_elapsed < ONE_SECOND)
                return;

            _elapsed %= ONE_SECOND;
            OnTicked(new ClockInfo(Now.Hour, Now.Minute, Now.Second));
        }

        private void OnTicked(ClockInfo info)
        {
            Ticked?.Invoke(info);
        }

        private void ApplicationFocusChanged(bool hasFocus)
        {
            if (hasFocus)
                OnTicked(new ClockInfo(Now.Hour, Now.Minute, Now.Second));
        }
    }
}