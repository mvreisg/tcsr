using System.Collections.ObjectModel;
using Assets.Model;

namespace Assets.Components.Entity.Controllable
{
    public interface IControllableComponent
    {
        public ReadOnlyCollection<IAct> Controllers { get; }
    }
}