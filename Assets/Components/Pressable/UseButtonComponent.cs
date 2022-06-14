using UnityEngine.EventSystems;

namespace Assets.Components.Pressable
{
    public class UseButtonComponent : EventTrigger,
        IPressableComponent
    {
        public event IPressableComponent.StateEventHandler Down;
        public event IPressableComponent.StateEventHandler Up;

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