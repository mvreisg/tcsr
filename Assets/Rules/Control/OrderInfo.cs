namespace Assets.Rules.Control
{
    public sealed class OrderInfo
    {
        private readonly IOrder _ordinator;
        private readonly Action _action;

        public OrderInfo(IOrder ordinator, Action action)
        {
            _ordinator = ordinator;
            _action = action;
        }

        public IOrder Ordinator => _ordinator;

        public Action Action => _action;
    }
}