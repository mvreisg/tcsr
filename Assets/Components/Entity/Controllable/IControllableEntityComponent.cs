using System.Collections.ObjectModel;
using Assets.Model;

namespace Assets.Components.Entity.Controllable
{
    public interface IControllableEntityComponent
    {
        ReadOnlyCollection<IAct> Controllers { get; }
    }
}