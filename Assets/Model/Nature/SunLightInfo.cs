namespace Assets.Model.Nature
{
    public sealed class SunlightInfo
    {
        private readonly float _intensity;

        public SunlightInfo(float intensity)
        {
            _intensity = intensity;
        }

        public float Intensity => _intensity;
    }
}