using UnityEngine;
using Assets.Resources.Components;

namespace Assets.Resources.Model.Controllers
{
    public class GUIController : Controller
    {
        public GUIController(
            Transform transform, 
            bool canControl,
            BackButtonComponent backButtonComponent,
            ForwardButtonComponent forwardButtonComponent) : 
            base(transform, canControl)
        {
            backButtonComponent.Up += ListenBackButtonUp;
            backButtonComponent.Down += ListenBackButtonDown;
            forwardButtonComponent.Up += ListenForwardButtonUp;
            forwardButtonComponent.Down += ListenForwardButtonDown;
        }

        public override void Do()
        {
            Debug.Log("GUIController...");
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