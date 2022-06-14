namespace Assets.Model
{
    public interface IPicker
    {
        delegate void PickEventHandler(PickInfo pickInfo);
        event PickEventHandler Picked;

        void Pick(PickInfo pickInfo);

        void OnPicked(PickInfo pickInfo);
    }
}