using UnityEngine;
using Assets.Scripts;

namespace Assets.Rules.Nature
{
    public class SunLight :  
        IRule,
        ILight,
        ISunLight,
        IDayListener
    {
        public event ISunLight.SunLightEventHandler Shined;

        public const float FADE_IN = Day.SECONDS_PER_HOUR * 6f;
        public const float IN = Day.SECONDS_PER_HOUR * 7f;
        public const float FADE_OUT = Day.SECONDS_PER_HOUR * 17f;
        public const float OUT = Day.SECONDS_PER_HOUR * 18f;

        private readonly Transform _transform;
        private readonly Light _light;

        private float _intensity;

        public SunLight(Transform transform)
        {
            _transform = transform;
            _light = transform.GetComponent<Light>();
        }

        public Transform Transform => _transform;

        public Light Light => _light;

        public void Awake()
        {
            
        }

        public void Start()
        {
            IDayScript script = Object.FindObjectOfType<DayScript>();
            script.Day.SecondPassed += ListenDay;
        }

        public void Update()
        {
            
        }

        public void Shine()
        {
            Light.intensity = _intensity;
            OnShined(new SunLightInfo(_intensity));
        }

        public void OnShined(SunLightInfo info)
        {
            Shined?.Invoke(info);
        }

        public void ListenDay(DayInfo info)
        {
            int hour = (int)info.Hour;
            int minute = (int)info.Minute;
            int second = (int)info.Second;
            float day = hour * Day.SECONDS_PER_HOUR + minute * Day.SECONDS_PER_MINUTE + second;
            float intensity = 0f;
            if (day > IN && day < FADE_OUT)
            {
                intensity = 1f;
            }
            if (day >= FADE_IN && day <= IN)
            {
                intensity = (day - FADE_IN) / (IN - FADE_IN);
            }
            if (day >= FADE_OUT && day <= OUT)
            {
                intensity = (OUT - day) / (OUT - FADE_OUT);
            }
            _intensity = intensity;
            Shine();
        }
    }
}