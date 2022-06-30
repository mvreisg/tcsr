namespace Assets.Rules.Nature
{
    public interface ISunLight
    {
        delegate void SunLightEventHandler(SunLightInfo info);
        event SunLightEventHandler Shined;

        void Shine();

        void OnShined(SunLightInfo info);
    }
}