using UnityEngine;

namespace Assets.Resources.Model.Controllers
{
    public abstract class Controller : Entity
    {
        public delegate void ActionEventHandler(Action action);
        public event ActionEventHandler Acted;

        private bool _canControl;

        public Controller(Transform transform, bool canCantrol) : base(transform)
        {
            CanControl = canCantrol;
        }

        public bool CanControl
        {
            get => _canControl;
            set => _canControl = value;
        }

        public void OnActed(Action action)
        {
            Acted?.Invoke(action);
        }
    }
}