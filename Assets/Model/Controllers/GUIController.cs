using Assets.Components.Pressable;

namespace Assets.Model.Controllers
{
    public class GUIController : 
        IAct
    {
        public event IAct.ActEventHandler Acted;

        public delegate void GUIEventHandler(bool overriding);
        public event GUIEventHandler Override;

        public GUIController(
            IPressableComponent backButton, 
            IPressableComponent forwardButton,
            IPressableComponent useButton
        )
        {
            backButton.Down += ListenBackButtonDown;
            backButton.Up += ListenBackButtonUp;
            forwardButton.Down += ListenForwardButtonDown;
            forwardButton.Up += ListenForwardButtonUp;
            useButton.Down += ListenUseButtonDown;
            useButton.Up += ListenUseButtonUp;
            OnOverride(false);
            Act(Action.STOP);
            Act(Action.IDLE);
        }

        private void ListenBackButtonDown()
        {
            OnOverride(true);
            Act(Action.BACK);
        }

        private void ListenBackButtonUp()
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

        private void ListenForwardButtonUp()
        {
            OnOverride(false);
            Act(Action.STOP);
            Act(Action.IDLE);
        }

        private void ListenUseButtonUp()
        {
            OnOverride(false);
            Act(Action.STOP);
            Act(Action.IDLE);
        }

        private void ListenUseButtonDown()
        {
            OnOverride(true);
            Act(Action.STOP);
            Act(Action.IDLE);
            Act(Action.USE);
        }

        public void Act(Action action)
        {
            OnActed(new ActionInfo<IAct>(this, action));
        }

        public void OnActed(ActionInfo<IAct> actionInfo)
        {
            Acted?.Invoke(actionInfo);
        }

        public void OnOverride(bool overriding)
        {
            Override?.Invoke(overriding);
        }
    }
}