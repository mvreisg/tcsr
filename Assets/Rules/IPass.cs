namespace Assets.Rules
{
    public interface IPass
    {
        delegate void PassEventHandler(LateInfo info);
        event PassEventHandler Passed;

        void Pass();

        void OnPassed(LateInfo info);
    }
}