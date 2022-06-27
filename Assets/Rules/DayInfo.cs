namespace Assets.Rules
{
    public sealed class DayInfo
    {
        private readonly float _hour;
        private readonly float _minute;
        private readonly float _second;

        public DayInfo(float hour, float minute, float second)
        {
            _hour = hour;
            _minute = minute;
            _second = second;
        }

        public override string ToString()
        {
            return string.Format(
                "{0}:{1}:{2}", 
                Hour, 
                Minute, 
                Second
            );
        }

        public float Hour => _hour;

        public float Minute => _minute;

        public float Second => _second;
    }
}