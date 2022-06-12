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
            OnActed(new ActionInfo(null, action));
        }

        public void OnActed(ActionInfo actionInfo)
        {
            Acted?.Invoke(actionInfo);
        }

        public void ListenAction(ActionInfo actionInfo)
        {
            switch (actionInfo.Action)
            {
                default:
                    throw new UnityException($"unhandled state: {actionInfo.Action}");
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
                        actionInfo.Entity.Transform.position, 
                        _transform.position
                    );

                    if (suggested > actual)
                    {
                        Act(Action.STOP);
                        Act(Action.IDLE);
                        return;
                    }

                    float targetX = actionInfo.Entity.Transform.position.x;
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

        public void ListenMovement(Vector3 target)
        {
            _target = target;
        }
    }
}