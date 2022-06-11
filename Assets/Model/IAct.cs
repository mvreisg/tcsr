namespace Assets.Model
{
    /// <summary>
    ///     <para>A Entity that can act.</para>
    /// </summary>
    public interface IAct
    {
        delegate void ActEventHandler(Action action);
        event ActEventHandler Acted;

        void OnActed(Action action);
    }
}