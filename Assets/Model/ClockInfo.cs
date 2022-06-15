namespace Assets.Model
{
    public sealed class ClockInfo
    {
        private readonly int _hour;
        private readonly int _minute;
        private readonly int _second;

        public ClockInfo(int hour, int minute, int second)
        {
            _hour = hour;
            _minute = minute;
            _second = second;
        }

        public int Hour => _hour;

        public int Minute => _minute;

        public int Second => _second;
    }
}