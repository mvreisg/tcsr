using Assets.Rules.Items;

namespace Assets.Rules
{
    public interface IUsable
    {
        delegate void UsableEventHandler(UsableInfo info);
        event UsableEventHandler BeingUsed;
        event UsableEventHandler WasUsed;

        ItemTypes Type { get; }

        bool Using { get; }

        void Use();

        void OnBeingUsed(UsableInfo info);

        void OnWasUsed(UsableInfo info);
    }
}