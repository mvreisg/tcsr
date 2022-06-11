using Assets.Components;

namespace Assets.Model.Controllers
{
    public class GUIController : 
        IAct
    {
        public event IAct.ActEventHandler Acted;

        public GUIController(IPressableComponent backButton, IPressableComponent forwardButton)
        {
            backButton.Up += ListenBackButtonUp;
            backButton.Down += ListenBackButtonDown;
            forwardButton.Up += ListenForwardButtonUp;
            forwardButton.Down += ListenForwardButtonDown;
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

        public void OnActed(Action action)
        {
            Acted?.Invoke(action);
        }
    }
}