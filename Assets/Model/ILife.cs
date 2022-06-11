using Assets.Model.Bio;

namespace Assets.Model
{
    public interface ILife
    {
        delegate void LifeStateHandler(IEntity me);
        event LifeStateHandler Born;
        event LifeStateHandler Died;

        BioState BioState { get; }

        void OnBorn();
        void OnDied();
    }
}
