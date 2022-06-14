namespace Assets.Model
{
    public interface IUse
    {
        delegate void UseEventHandler(UseInfo useInfo);
        event UseEventHandler Used;

        void Use();

        void OnUsed();
    }
}