using System;
using UnityEngine;

namespace Assets.Model.Belong
{
    public sealed class Clock : 
        IEntity,
        IRenderable
    {
        public delegate void ClockEventHandler(ClockInfo info);
        public event ClockEventHandler Ticked;

        private const float ONE_SECOND = 1f;

        private readonly Transform _transform;
        private readonly SpriteRenderer _spriteRenderer;

        private float _elapsed;

        public Clock(Transform transform)
        {
            _transform = transform;
            _spriteRenderer = transform.GetComponent<SpriteRenderer>();
            Application.focusChanged += ApplicationFocusChanged;
        }

        public Transform Transform => _transform;

        public Renderer Renderer => _spriteRenderer;
        
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
            if (_elapsed >= ONE_SECOND)
            {
                _elapsed %= ONE_SECOND;
                OnTicked(new ClockInfo(Now.Hour, Now.Minute, Now.Second));
            }
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