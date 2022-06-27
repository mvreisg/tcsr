using Assets.Rules;

namespace Assets.Scripts
{
    public interface IRuleScript
    {
        public IRule Rule { get; }
    }
}