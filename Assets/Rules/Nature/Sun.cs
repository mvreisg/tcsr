using UnityEngine;
using Assets.Scripts;

namespace Assets.Rules.Nature
{
    public class Sun : 
        IRule,
        IRenderable
    {
        private const float RISE = Day.SECONDS_PER_HOUR * 6f;
        private const float PEAK = Day.SECONDS_PER_HOUR * 12f;
        private const float SET = Day.SECONDS_PER_HOUR * 18f;

        private readonly Transform _transform;
        private readonly SpriteRenderer _spriteRenderer;

        private readonly float _lowest;
        private readonly float _peak;

        public Sun(Transform transform, float lowest, float peak)
        {
            _transform = transform;
            _lowest = lowest;
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
            ((Object.FindObjectOfType<DayScript>() as IRuleScript).Rule as Day).SecondPassed += ListenClock;
        }

        public void Update()
        {
            
        }

        // Class originals

        public void ListenClock(DayInfo info)
        {
            int hour = (int)info.Hour;
            int minute = (int)info.Minute;
            int second = (int)info.Second;
            float day = hour * Day.SECONDS_PER_HOUR + minute * Day.SECONDS_PER_MINUTE + second;
            float y = _lowest;
            float delta = Mathf.Abs(_lowest) + Mathf.Abs(_peak);
            if (day > RISE && day <= PEAK)
            {
                float ratio = (day - RISE) / (PEAK - RISE);
                y = _lowest + delta * ratio;
            }
            if (day > PEAK && day < SET)
            {
                float ratio = (day - PEAK) / (SET - PEAK);
                y = _peak - delta * ratio;
            }
            Transform.position = new Vector3(0f, y, 0f);
        }
    }
}