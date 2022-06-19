using UnityEngine;
using Assets.Model.Belong;

namespace Assets.Model.Nature
{
    public class Sun : 
        IModel,
        IRenderable
    {
        private const int RISE = 6;
        private const int PEAK = 12;
        private const int SET = 18;

        private readonly Transform _transform;
        private readonly SpriteRenderer _spriteRenderer;

        private readonly float _low;
        private readonly float _peak;

        public Sun(Transform transform, float low, float peak)
        {
            _transform = transform;
            _low = low;
            _peak = peak;
            _spriteRenderer = transform.GetComponent<SpriteRenderer>();
        }

        public Transform Transform => _transform;

        public Renderer Renderer => _spriteRenderer;

        public void Awake()
        {
            
        }

        public void Start()
        {
            
        }

        public void Update()
        {
            
        }

        // Class originals

        public void ListenEarthClockTick(ClockInfo info)
        {
            float hour = info.Hour;
            float minute = info.Minute;
            float second = info.Second;
            if (hour >= RISE && hour <= PEAK)
            {
                float t = hour * 60f + minute * 60f + second / Clock.ONE_HOUR_IN_SECONDS * 12f;
                float y = Mathf.Lerp(
                    _low,
                    _peak,
                    t
                );
                Transform.position = new Vector3(0f, y, 0f);
                Debug.LogFormat(
                    "Morning. {0}:{1}:{2}, y: {3}, t: {4}",
                    hour,
                    minute,
                    second,
                    y,
                    t
                );
            }
            else if (hour < SET)
            {
                float t = (Clock.ONE_HOUR_IN_SECONDS * 18f - (hour * 60f + minute * 60f + second)) / Clock.ONE_HOUR_IN_SECONDS * 18f;
                float y = Mathf.Lerp(
                    _low,
                    _peak,
                    t
                );
                Transform.position = new Vector3(0f, y, 0f);
                Debug.LogFormat(
                    "Afternoon. {0}:{1}:{2}, y: {3}, t: {4}",
                    hour,
                    minute,
                    second,
                    y,
                    t
                );
            }
            else // SETTED
            {
                Transform.position = new Vector3(0f, _low, 0f);
                return;
            }
        }
    }
}