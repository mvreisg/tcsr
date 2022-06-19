namespace Assets.Model
{
    /// <summary>
    ///     <para>Something that can act and notify their action.</para>
    /// </summary>
    public interface IAct
    {
        delegate void ActEventHandler(ActionInfo info);
        event ActEventHandler Acted;

        void Act(Action action);

        void OnActed(ActionInfo info);
    }
}