namespace Assets.Rules.Control
{
    /// <summary>
    ///     <para>Something that emit orders.</para>
    /// </summary>
    public interface IOrder
    {
        delegate void OrderEventHandler(OrderInfo info);
        event OrderEventHandler Ordered;

        void Order(Action action);

        void OnOrdered(OrderInfo info);
    }
}