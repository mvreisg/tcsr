namespace Assets.Model
{
    /// <summary>
    ///     <para>A Entity that can act.</para>
    /// </summary>
    public interface IAct
    {
        delegate void ActEventHandler(ActionInfo<IAct> actionInfo);
        event ActEventHandler Acted;

        void Act(Action action);

        void OnActed(ActionInfo<IAct> actionInfo);
    }
}