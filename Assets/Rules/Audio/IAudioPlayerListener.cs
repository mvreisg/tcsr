namespace Assets.Rules.Audio
{
    public interface IAudioPlayerListener
    {
        void ListenPlay(AudioPlayerInfo info);

        void ListenPause(AudioPlayerInfo info);

        void ListenResume(AudioPlayerInfo info);

        void ListenStop(AudioPlayerInfo info);

        void ListenSkip(AudioPlayerInfo info);
    }
}