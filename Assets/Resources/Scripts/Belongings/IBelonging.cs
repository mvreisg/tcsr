namespace Assets.Resources.Scripts.Belongings
{
    public interface IBelonging
    {
        bool ToUse { get; }
        bool Using { get; }
        void Use();
    }
}

