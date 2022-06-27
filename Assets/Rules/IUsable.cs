using Assets.Rules.Items;

namespace Assets.Rules
{
    public interface IUsable
    {
        delegate void UsableEventHandler(UsableInfo info);
        event UsableEventHandler Used;

        Item Type { get; }

        bool Using { get; }

        void Use();

        void OnUsed();

        void ListenUse(UseInfo info);
    }
}