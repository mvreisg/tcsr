using System;
using UnityEngine;

namespace Assets.Resources.Model
{
    public class Sun : Entity
    {
        private readonly DateTime theDay = new DateTime(DateTime.Now.Year, 5, 25, 0, 0, 0, 0);
        private DateTime Midnight => theDay;
        private DateTime SunRise => theDay.AddHours(6);
        private DateTime MidDay => theDay.AddHours(12);
        private DateTime SunSet => theDay.AddHours(18);
        private DateTime AnotherTranslation => theDay.AddHours(24);

        private Light _sun;

        public enum State
        {
            NONE,
            DAWN,
            MORNING,
            AFTERNOON,
            NIGHT
        }

        public State NowIs
        {
            get
            {
                if (DateTime.Compare(DateTime.Now, AnotherTranslation) < 0)
                    return State.NIGHT;
                else if (DateTime.Compare(DateTime.Now, SunSet) < 0)
                    return State.AFTERNOON;
                else if (DateTime.Compare(DateTime.Now, MidDay) < 0)
                    return State.MORNING;
                else if (DateTime.Compare(DateTime.Now, SunRise) < 0)
                    return State.DAWN;
                else
                    return State.NONE;
            }
        }

        public float Intensity
        {
            get => throw new UnityException("implement");
            set => _sun.intensity = value;
        }

        public Sun(Transform transform, Light sun) : base(transform, Multiplier.ZERO, Multiplier.ZERO, Multiplier.ZERO, XYZValue.ZERO)
        {
            _sun = sun;
        }

        public void UpdateIntensity()
        {
            _sun.intensity = Intensity;
        }
    }
}