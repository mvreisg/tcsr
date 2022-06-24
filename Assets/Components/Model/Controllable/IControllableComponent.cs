using System.Collections.ObjectModel;
using Assets.Model;

namespace Assets.Components.Model.Controllable
{
    public interface IControllableComponent
    {
        public ReadOnlyCollection<IAct> Controllers { get; }
    }
}