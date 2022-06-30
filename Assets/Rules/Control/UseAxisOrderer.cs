using UnityEngine;

namespace Assets.Rules.Control
{
    public class UseAxisOrderer :
        IRule,
        IOrder,
        IOrderListener
    {
        public event IOrder.OrderEventHandler Ordered;

        private readonly Transform _transform;

        private float _axis;
        private bool _skip;

        public UseAxisOrderer(Transform transform)
        {
            _transform = transform;
        }

        public Transform Transform => _transform;

        public Orderers Type => Orderers.AXIS;

        public void Awake()
        {
            _skip = false;
        }

        public void Start()
        {

        }

        public void Update()
        {
            if (_skip)
                return;

            _axis = Input.GetAxisRaw("Use");
            if (_axis > 0f)
            {
                Order(Action.STOP);
                Order(Action.USE);
                Order(Action.IDLE);
            }
        }

        public void Order(Action action)
        {
            OnOrdered(new OrderInfo(this, action));
        }

        public void OnOrdered(OrderInfo info)
        {
            Ordered?.Invoke(info);
        }

        public void ListenOrder(OrderInfo info)
        {
            IOrder orderer = info.Orderer;
            if (!orderer.Type.Equals(Orderers.GUI))
                return;
            Action action = info.Action;
            switch (action)
            {
                default:
                    throw new UnityException(string.Format("Unhandled state: {0}", action));
                case Action.IDLE:
                case Action.STOP:
                case Action.TURN_BACK:
                case Action.BACK:
                case Action.TURN_FORWARD:
                case Action.FORWARD:
                    _skip = false;
                    break;
                case Action.USE:
                    _skip = true;
                    break;
            }
        }
    }
}