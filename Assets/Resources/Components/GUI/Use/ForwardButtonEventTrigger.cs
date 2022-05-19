using UnityEngine.EventSystems;
using Assets.Resources.Pure;

namespace Assets.Resources.Components.GUI.Use
{
    public class ForwardButtonEventTrigger : EventTrigger
    {
        public delegate void PressedEventHandler(GUIMovePressed pressed);

        public event PressedEventHandler Pressed;

        public override void OnPointerDown(PointerEventData eventData)
        {
            OnPressed(Pure.GUIMovePressed.FORWARD);
            base.OnPointerDown(eventData);
        }

        public override void OnPointerUp(PointerEventData eventData)
        {
            OnPressed(Pure.GUIMovePressed.NOTHING);
            base.OnPointerUp(eventData);
        }

        private void OnPressed(GUIMovePressed pressed)
        {
            Pressed?.Invoke(pressed);
        }
    }
}