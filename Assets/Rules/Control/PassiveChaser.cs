using UnityEngine;

namespace Assets.Rules.Control
{
    public class PassiveChaser : 
        IOrder
    {
        public event IOrder.OrderEventHandler Ordered;

        private readonly Transform _transform;

        private Vector3 _target;

        public PassiveChaser(Transform transform)
        {
            _transform = transform;
        }

        public void Order(Action action)
        {
            OnOrdered(new OrderInfo(this, action));
        }

        public void OnOrdered(OrderInfo info)
        {
            Ordered?.Invoke(info);
        }

        // Class originals

        public void ListenAction(ActionInfo info)
        {
            IAct actor = info.Actor;
            if (actor is not IRule)
                return;
            IRule entity = actor as IRule;
            Action action = info.Action;
            switch (action)
            {
                default:
                    throw new UnityException($"unhandled state: {action}");
                case Action.STOP:
                case Action.IDLE:
                    Order(Action.STOP);
                    Order(Action.IDLE);
                    break;
                case Action.FORWARD:
                case Action.BACK:
                    if (_target == null)
                    {
                        Order(Action.STOP);
                        Order(Action.IDLE);
                        return;
                    }
                    float actual = Vector3.Distance(
                        _target, 
                        _transform.position
                    );
                    float suggested = Vector3.Distance(
                        entity.Transform.position, 
                        _transform.position
                    );

                    if (suggested > actual)
                    {
                        Order(Action.STOP);
                        Order(Action.IDLE);
                        return;
                    }

                    float targetX = entity.Transform.position.x;
                    float thisX = _transform.position.x;
                    if (thisX < targetX)
                        Order(Action.FORWARD);
                    else if (thisX > targetX)
                        Order(Action.BACK);
                    else
                    {
                        Order(Action.STOP);
                        Order(Action.IDLE);
                    }
                    break;
                case Action.USE:
                    break;
            }
        }

        public void ListenMovement(MovementInfo movementInfo)
        {
            _target = movementInfo.Position;
        }
    }
}