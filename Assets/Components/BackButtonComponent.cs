using UnityEngine.EventSystems;

namespace Assets.Components
{
    public class BackButtonComponent : EventTrigger
    {
        public delegate void BackButtonEventHandler();
        public event BackButtonEventHandler Down;
        public event BackButtonEventHandler Up;

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