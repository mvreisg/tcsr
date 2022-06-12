namespace Assets.Model
{
    /// <summary>
    ///     <para>A Entity that can act.</para>
    /// </summary>
    public interface IAct
    {
        delegate void ActEventHandler(ActionInfo actionInfo);
        event ActEventHandler Acted;

        void Act(Action action);

        void OnActed(ActionInfo actionInfo);
    }
}