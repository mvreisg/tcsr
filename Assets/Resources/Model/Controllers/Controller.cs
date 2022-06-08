using UnityEngine;

namespace Assets.Resources.Model.Controllers
{
    public abstract class Controller : Entity
    {
        public delegate void ActionEventHandler(Action action);
        public event ActionEventHandler Acted;

        public Controller(Transform transform) : base(transform)
        {

        }

        public void OnActed(Action action)
        {
            Acted?.Invoke(action);
        }
    }
}