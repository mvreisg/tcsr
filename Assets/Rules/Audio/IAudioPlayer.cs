using System.Collections.ObjectModel;

namespace Assets.Rules.Audio
{
    public interface IAudioPlayer
    {
        delegate void AudioPlayerEventHandler(AudioPlayerInfo info);
        event AudioPlayerEventHandler Played;
        event AudioPlayerEventHandler Paused;
        event AudioPlayerEventHandler Resumed;
        event AudioPlayerEventHandler Stopped;
        event AudioPlayerEventHandler Skipped;

        ReadOnlyCollection<AudioInfo> AudiosInfo { get; }

        void Play();

        void Pause();

        void Resume();

        void Stop();

        void Skip();

        void OnPlay(AudioPlayerInfo info);

        void OnPause(AudioPlayerInfo info);

        void OnResume(AudioPlayerInfo info);

        void OnStop(AudioPlayerInfo info);

        void OnSkip(AudioPlayerInfo info);
    }
}