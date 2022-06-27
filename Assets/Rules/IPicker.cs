namespace Assets.Rules
{
    public interface IPicker
    {
        delegate void PickerEventHandler(PickInfo info);
        event PickerEventHandler Picked;

        void Pick(PickInfo info);

        void OnPicked(PickInfo info);
    }
}