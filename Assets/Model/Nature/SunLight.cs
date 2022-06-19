using UnityEngine;
using Assets.Model.Belong;

namespace Assets.Model.Nature
{
    public class SunLight :  
        IEntity,
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

        // Class originals

        public void ListenUniversalClockTick(ClockInfo info)
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
                intensity = minute * 60f + second / Clock.ONE_HOUR;
                emit = true;
            }
            else if (hour == 17)
            {
                intensity = Clock.ONE_HOUR - (minute * 60f + second) / Clock.ONE_HOUR;
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

        public Transform Transform => _transform;

        public Light Light => _light;

        public void Update()
        {

        }

        // Class originals

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