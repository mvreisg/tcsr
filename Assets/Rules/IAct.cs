namespace Assets.Rules
{
    /// <summary>
    ///     <para>Something that can act and notify their action.</para>
    /// </summary>
    public interface IAct
    {
        delegate void ActEventHandler(ActionInfo info);
        event ActEventHandler Acted;

        Facing Facing { get; }

        void Act(Action action);

        void OnActed(ActionInfo info);
    }
}