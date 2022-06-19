using UnityEngine;
using Assets.Model.Belong;

namespace Assets.Model.Nature
{
    public class SunLight :  
        IModel,
        ILight
    {
        public delegate void SunLightEventHandler(SunLightInfo info);
        public event SunLightEventHandler Shun;

        private readonly Transform _transform;
        private readonly Light _light;

        public SunLight(Transform transform)
        {
            _transform = transform;
            _light = transform.GetComponent<Light>();
            Shun += ListenShun;
        }

        public Transform Transform => _transform;

        public Light Light => _light;

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
            float intensity;
            bool emit;

            if (hour < 6 || hour > 18)
            {
                intensity = 0f;
                emit = true;
            }
            else if (hour >= 7 && hour <= 17)
            {
                intensity = 1f;
                emit = true;
            }
            else if (hour == 6)
            {
                intensity = minute * 60f + second / Clock.ONE_HOUR_IN_SECONDS;
                emit = true;
            }
            else if (hour == 17)
            {
                intensity = Clock.ONE_HOUR_IN_SECONDS - (minute * 60f + second) / Clock.ONE_HOUR_IN_SECONDS;
                emit = true;
            }
            else
            {
                intensity = 0f;
                emit = false;
            }

            if (!emit)
                return;
            else
                OnShun(new SunLightInfo(intensity));
        }

        private void OnShun(SunLightInfo info)
        {
            Shun?.Invoke(info);
        }

        private void ListenShun(SunLightInfo info)
        {
            Light.intensity = info.Intensity;
        }
    }
}