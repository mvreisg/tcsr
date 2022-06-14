namespace Assets.Model
{
    public interface IUseable
    {
        delegate void UseableEventHandler(UseableInfo useInfo);
        event UseableEventHandler Used;

        void FixedUse();

        void OnUsed();
    }
}