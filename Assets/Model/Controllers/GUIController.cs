using Assets.Components.Pressable;

namespace Assets.Model.Controllers
{
    public class GUIController : 
        IAct
    {
        public event IAct.ActEventHandler Acted;

        public delegate void GUIEventHandler(bool overriding);
        public event GUIEventHandler Overriden;

        private bool _back;
        private bool _forward;

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
            Override(false);
            Act(Action.STOP);
            Act(Action.IDLE);
        }

        private void ListenBackButtonDown()
        {
            if (_forward)
                return;
            Override(true);
            _back = true;
            Act(Action.BACK);
        }

        private void ListenBackButtonUp()
        {
            _back = false;
            Act(Action.STOP);
            Act(Action.IDLE);
            Override(false);
        }

        private void ListenForwardButtonDown()
        {
            if (_back)
                return;
            Override(true);
            _forward = true;
            Act(Action.FORWARD);
        }

        private void ListenForwardButtonUp()
        {
            _forward = false;
            Act(Action.STOP);
            Act(Action.IDLE);
            Override(false);
        }

        private void ListenUseButtonUp()
        {
            Act(Action.STOP);
            Act(Action.IDLE);
            Override(false);
        }

        private void ListenUseButtonDown()
        {
            Override(true);
            Act(Action.STOP);
            Act(Action.IDLE);
            Act(Action.USE);
        }

        public void Act(Action action)
        {
            OnActed(new ActionInfo(this, action));
        }

        public void OnActed(ActionInfo info)
        {
            Acted?.Invoke(info);
        }

        private void Override(bool will)
        {
            OnOverriden(will);
        }

        private void OnOverriden(bool overriding)
        {
            Overriden?.Invoke(overriding);
        }
    }
}