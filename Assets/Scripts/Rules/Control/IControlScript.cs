using System.Collections.ObjectModel;
using Assets.Rules.Control;

namespace Assets.Scripts.Rules.Control
{
    public interface IControlScript
    {
        public ReadOnlyCollection<IOrder> Controllers { get; }
    }
}