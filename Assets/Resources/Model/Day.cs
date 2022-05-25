using System;
using UnityEngine;

namespace Assets.Resources.Model
{
    public class Day : Entity
    {
        private readonly DateTime _day;

        private DateTime SunRise => _day.AddHours(6);
        private DateTime MidDay => _day.AddHours(12);
        private DateTime SunSet => _day.AddHours(18);
        private DateTime AnotherTranslation => _day.AddHours(24);

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
                if (DateTime.Compare(DateTime.Now, SunRise) < 0)
                    return State.DAWN;
                else if (DateTime.Compare(DateTime.Now, MidDay) < 0)
                    return State.MORNING;
                else if (DateTime.Compare(DateTime.Now, SunSet) < 0)
                    return State.AFTERNOON;
                else if (DateTime.Compare(DateTime.Now, AnotherTranslation) < 0)
                    return State.NIGHT;
                else
                    return State.NONE;
            }
        }

        public float Intensity
        {
            get {
                float max = 60f * 60f * 6f; // 6h in s
                float elapsed;
                switch (NowIs)
                {
                    case State.NONE:
                    case State.DAWN:
                    case State.NIGHT:
                        return 0f;
                    case State.MORNING:
                        elapsed = (float)(MidDay - DateTime.Now).TotalSeconds;
                        return (max - elapsed) / max;
                    case State.AFTERNOON:
                        elapsed = (float)(SunSet - DateTime.Now).TotalSeconds;
                        return elapsed / max;
                    default:
                        throw new UnityException($"unhandled state: {NowIs}");
                }
            }
            private set => _sun.intensity = value;
        }

        public Day(Transform transform, DateTime day, Light sun) : base(transform, Multiplier.ZERO, Multiplier.ZERO, Multiplier.ZERO, XYZValue.ZERO)
        {
            _day = day;
            _sun = sun;
        }

        public void ShineOnYouCrazyDiamond()
        {
            _sun.intensity = Intensity;
        }
    }
}