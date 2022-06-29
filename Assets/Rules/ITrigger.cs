using UnityEngine;

namespace Assets.Rules
{
    public interface ITrigger
    {
        delegate void TriggerEventHandler(TriggerInfo info);
        event TriggerEventHandler TriggerEntered;
        event TriggerEventHandler TriggerExited;

        void OnTriggerEnter2D(Collider2D collider);

        void OnTriggerExit2D(Collider2D collider);
    }
}