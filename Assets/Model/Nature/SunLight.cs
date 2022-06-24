using UnityEngine;
using Assets.Components.Model;
using Assets.Model.Belong;

namespace Assets.Model.Nature
{
    public class Sunlight :  
        IModel,
        ILight
    {
        public delegate void SunlightEventHandler(SunlightInfo info);
        public event SunlightEventHandler Shun;

        public const float FADE_IN = Clock.SECONDS_PER_HOUR * 6f;
        public const float IN = Clock.SECONDS_PER_HOUR * 7f;
        public const float FADE_OUT = Clock.SECONDS_PER_HOUR * 17f;
        public const float OUT = Clock.SECONDS_PER_HOUR * 18f;

        private readonly Transform _transform;
        private readonly Light _light;

        public Sunlight(Transform transform)
        {
            _transform = transform;
            _light = transform.GetComponent<Light>();
        }

        public Transform Transform => _transform;

        public Light Light => _light;

        public void Awake()
        {
            Shun += ListenShun;
        }

        public void Start()
        {
            ((Object.FindObjectOfType<DayComponent>() as IModelComponent).Model as Clock).Ticked += ListenDay;
        }

        public void Update()
        {

        }

        // Class originals

        public void ListenDay(ClockInfo info)
        {
            int hour = (int)info.Hour;
            int minute = (int)info.Minute;
            int second = (int)info.Second;
            float day = hour * Clock.SECONDS_PER_HOUR + minute * Clock.SECONDS_PER_MINUTE + second;
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
            OnShun(new SunlightInfo(intensity));
        }

        private void OnShun(SunlightInfo info)
        {
            Shun?.Invoke(info);
        }

        private void ListenShun(SunlightInfo info)
        {
            Light.intensity = info.Intensity;
        }
    }
}