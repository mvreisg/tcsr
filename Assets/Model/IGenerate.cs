namespace Assets.Model
{
    public interface IGenerate
    {
        delegate void GenerateEventHandler(GenerationInfo info);
        event GenerateEventHandler Generated;

        void Generate();

        void OnGenerated(GenerationInfo info);
    }
}