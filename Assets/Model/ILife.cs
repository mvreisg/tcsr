using Assets.Model.Bio;

namespace Assets.Model
{
    public interface ILife
    {
        BioState BioState { get; }
    }
}