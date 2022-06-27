using UnityEngine.EventSystems;

namespace Assets.Scripts.Pressable
{
    public class BackButtonScript : EventTrigger,
        IPressableScript
    {
        public event IPressableScript.StateEventHandler Down;
        public event IPressableScript.StateEventHandler Up;

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