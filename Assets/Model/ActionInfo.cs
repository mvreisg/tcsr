namespace Assets.Model
{
    public sealed class ActionInfo
    {
        private readonly IAct _actor;
        private readonly Action _action;

        public ActionInfo(IAct actor, Action action)
        {
            _actor = actor;
            _action = action;
        }

        public IAct Actor => _actor;

        public Action Action => _action;
    }
}