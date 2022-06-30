namespace Assets.Rules
{
    public interface IDay
    {
        delegate void DayEventHandler(DayInfo info);
        event DayEventHandler SecondPassed;

        DayInfo DayInfo { get; }

        void PassSecond();

        void OnSecondPassed(DayInfo info);

        void ListenApplicationFocusChange(bool hasFocus);
    }
}