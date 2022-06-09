using UnityEngine;
using Assets.Components;

namespace Assets.Model.Controllers
{
    public class GUIController : Controller
    {
        public GUIController(
            Transform transform, 
            BackButtonComponent backButtonComponent, 
            ForwardButtonComponent forwardButtonComponent) : base(transform)
        {
            backButtonComponent.Up += ListenBackButtonUp;
            backButtonComponent.Down += ListenBackButtonDown;
            forwardButtonComponent.Up += ListenForwardButtonUp;
            forwardButtonComponent.Down += ListenForwardButtonDown;
        }

        public override void Do()
        {

        }

        private void ListenBackButtonUp()
        {
            OnActed(Action.STOP);
        }

        private void ListenBackButtonDown()
        {
            OnActed(Action.BACK);
        }

        private void ListenForwardButtonUp()
        {
            OnActed(Action.STOP);
        }

        private void ListenForwardButtonDown()
        {
            OnActed(Action.FORWARD);
        }
    }
}