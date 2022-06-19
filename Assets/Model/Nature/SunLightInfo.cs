namespace Assets.Model.Nature
{
    public sealed class SunLightInfo
    {
        private readonly float _intensity;

        public SunLightInfo(float intensity)
        {
            _intensity = intensity;
        }

        public float Intensity => _intensity;
    }
}