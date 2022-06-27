namespace Assets.Rules
{
    public sealed class ActionInfo
    {
        private readonly IAct _actor;
        private readonly Action _action;
        private readonly Facing _facing;

        public ActionInfo(IAct actor, Action action, Facing facing)
        {
            _actor = actor;
            _action = action;
            _facing = facing;
        }

        public IAct Actor => _actor;

        public Action Action => _action;

        public Facing Facing => _facing;
    }
}