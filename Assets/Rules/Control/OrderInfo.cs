namespace Assets.Rules.Control
{
    public sealed class OrderInfo
    {
        private readonly IOrder _orderer;
        private readonly Action _action;

        public OrderInfo(IOrder orderer, Action action)
        {
            _orderer = orderer;
            _action = action;
        }

        public IOrder Orderer => _orderer;

        public Action Action => _action;
    }
}