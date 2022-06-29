namespace Assets.Rules
{
    public interface ILate
    {
        delegate void PassEventHandler(LateInfo info);
        event PassEventHandler Passed;

        void Late();

        void OnPassed(LateInfo info);
    }
}