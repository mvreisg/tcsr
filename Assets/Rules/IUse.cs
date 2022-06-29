namespace Assets.Rules
{
    public interface IUse
    {
        delegate void UseEventHandler(UseInfo info);
        event UseEventHandler Used;

        void Use();

        void OnUsed(UseInfo info);
    }
}