namespace Assets.Model
{
    public sealed class ActionInfo<T> where T : IAct
    {
        private readonly T _actor;
        private readonly Action _action;

        public ActionInfo(T actor, Action action)
        {
            _actor = actor;
            _action = action;
        }

        public T Actor => _actor;

        public Action Action => _action;
    }
}