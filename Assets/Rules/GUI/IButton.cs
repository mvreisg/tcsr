namespace Assets.Rules.GUI
{
    public interface IButton
    {
        delegate void ButtonEventHandler(ButtonInfo info);
        event ButtonEventHandler StateChanged;

        void Press();

        void Release();

        void OnStateChanged(ButtonInfo info);
    }
}