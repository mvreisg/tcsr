namespace Assets.Model
{
    public sealed class ActionInfo
    {
        private readonly IEntity _entity;
        private readonly Action _action;

        public ActionInfo(IEntity entity, Action action)
        {
            _entity = entity;
            _action = action;
        }

        public IEntity Entity => _entity;

        public Action Action => _action;
    }
}