namespace Assets.Model
{
    public sealed class ClockInfo
    {
        private readonly float _hour;
        private readonly float _minute;
        private readonly float _second;

        public ClockInfo(float hour, float minute, float second)
        {
            _hour = hour;
            _minute = minute;
            _second = second;
        }

        public float Hour => _hour;

        public float Minute => _minute;

        public float Second => _second;
    }
}