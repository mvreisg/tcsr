using Assets.Components.Pressable;

namespace Assets.Model.Controllers
{
    public class GUIController : 
        IAct
    {
        public event IAct.ActEventHandler Acted;

        public delegate void GUIEventHandler(bool overriding);
        public event GUIEventHandler Override;

        public GUIController(IPressableComponent backButton, IPressableComponent forwardButton)
        {
            backButton.Up += ListenBackButtonUp;
            backButton.Down += ListenBackButtonDown;
            forwardButton.Up += ListenForwardButtonUp;
            forwardButton.Down += ListenForwardButtonDown;
            OnOverride(false);
            Act(Action.STOP);
            Act(Action.IDLE);
        }

        private void ListenBackButtonUp()
        {
            OnOverride(false);
            Act(Action.STOP);
            Act(Action.IDLE);
        }

        private void ListenBackButtonDown()
        {
            OnOverride(true);
            Act(Action.BACK);
        }

        private void ListenForwardButtonUp()
        {
            OnOverride(false);
            Act(Action.STOP);
            Act(Action.IDLE);
        }

        private void ListenForwardButtonDown()
        {
            OnOverride(true);
            Act(Action.FORWARD);
        }

        public void Act(Action action)
        {
            OnActed(new ActionInfo(null, action));
        }

        public void OnActed(ActionInfo actionInfo)
        {
            Acted?.Invoke(actionInfo);
        }

        public void OnOverride(bool overriding)
        {
            Override?.Invoke(overriding);
        }
    }
}