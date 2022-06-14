namespace Assets.Model
{
    /// <summary>
    ///     <para>Something that can act and notify his action.</para>
    /// </summary>
    public interface IAct
    {
        delegate void ActEventHandler(ActionInfo<IAct> actionInfo);
        event ActEventHandler Acted;

        void Act(Action action);

        void OnActed(ActionInfo<IAct> actionInfo);
    }
}