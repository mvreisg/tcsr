using UnityEngine.EventSystems;

namespace Assets.Resources.Components
{
    public class ForwardButtonComponent : EventTrigger
    {
        public delegate void ForwardButtonEventHandler();
        public event ForwardButtonEventHandler Down;
        public event ForwardButtonEventHandler Up;

        public override void OnPointerDown(PointerEventData eventData)
        {
            base.OnPointerDown(eventData);
            OnDown();
        }

        public override void OnPointerUp(PointerEventData eventData)
        {
            base.OnPointerUp(eventData);
            OnUp();
        }

        private void OnDown()
        {
            Down?.Invoke();
        }

        private void OnUp()
        {
            Up?.Invoke();
        }
    }
}