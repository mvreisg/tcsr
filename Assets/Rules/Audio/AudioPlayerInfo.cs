namespace Assets.Rules.Audio
{
    public sealed class AudioPlayerInfo
    {
        private readonly AudioInfo _audioInfo;

        public AudioPlayerInfo(AudioInfo audioInfo)
        {
            _audioInfo = audioInfo;
        }

        public AudioInfo AudioInfo => _audioInfo;
    }
}