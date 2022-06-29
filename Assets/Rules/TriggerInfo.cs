using UnityEngine;

namespace Assets.Rules
{
    public sealed class TriggerInfo
    {
        private ITrigger _invoker;
        private readonly Collider2D _collider;

        public TriggerInfo(ITrigger invoker, Collider2D collider)
        {
            _invoker = invoker;
            _collider = collider;
        }

        public ITrigger Invoker => _invoker;

        public Collider2D Collider => _collider;
    }
}