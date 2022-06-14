using UnityEngine;

namespace Assets.Model.Controllers
{
    public class ChaserAI : 
        IAct
    {
        public event IAct.ActEventHandler Acted;

        private readonly Transform _transform;
        private Vector3 _target;

        public ChaserAI(Transform transform)
        {
            _transform = transform;
            _target = Vector3.zero;
        }

        public void Act(Action action)
        {
            OnActed(new ActionInfo<IAct>(this, action));
        }

        public void OnActed(ActionInfo<IAct> actionInfo)
        {
            Acted?.Invoke(actionInfo);
        }

        public void ListenAction(ActionInfo<IAct> info)
        {
            IAct actor = info.Actor;
            if (actor is not IEntity)
                return;
            IEntity entity = actor as IEntity;
            Action action = info.Action;
            switch (action)
            {
                default:
                    throw new UnityException($"unhandled state: {action}");
                case Action.STOP:
                case Action.IDLE:
                    Act(Action.STOP);
                    Act(Action.IDLE);
                    break;
                case Action.FORWARD:
                case Action.BACK:
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
                        Act(Action.STOP);
                        Act(Action.IDLE);
                        return;
                    }

                    float targetX = entity.Transform.position.x;
                    float thisX = _transform.position.x;
                    if (thisX < targetX)
                        Act(Action.FORWARD);
                    else if (thisX > targetX)
                        Act(Action.BACK);
                    else
                    {
                        Act(Action.STOP);
                        Act(Action.IDLE);
                    }
                    break;
                case Action.USE:
                    break;
            }
        }

        public void ListenMovement(MovementInfo movementInfo)
        {
            _target = movementInfo.NewPosition;
        }
    }
}