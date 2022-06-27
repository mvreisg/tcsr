using Assets.Rules;

namespace Assets.Scripts.Rules
{
    public interface IRuleScript
    {
        public IRule Rule { get; }
    }
}