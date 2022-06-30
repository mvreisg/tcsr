using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;
using Assets.Scripts;

namespace Assets.Rules.Audio
{
    public class AudioPlayer :
        IRule,
        IAudioPlayer,
        IAudioPlayerListener,
        INoisier,
        IDayListener
    {
        public event IAudioPlayer.AudioPlayerEventHandler Played;
        public event IAudioPlayer.AudioPlayerEventHandler Paused;
        public event IAudioPlayer.AudioPlayerEventHandler Resumed;
        public event IAudioPlayer.AudioPlayerEventHandler Stopped;
        public event IAudioPlayer.AudioPlayerEventHandler Skipped;

        private const float ZERO_NEXT_TIME = 0f;
        private const float DEFAULT_SILENCE = 1f;
        private const int START_INDEX = -1;

        private readonly Transform _transform;
        private readonly AudioSource _audioSource;
        private readonly List<AudioInfo> _audiosInfo;

        private float _day;
        private int _index;
        private float _nextTime;
        private float _silence;
        private bool _loop;
        private bool _playing;

        public AudioPlayer(Transform transform, List<AudioInfo> audiosInfo)
        {
            _transform = transform;
            _audiosInfo = audiosInfo;
            _audioSource = transform.GetComponent<AudioSource>();
        }

        public Transform Transform => _transform;

        public ReadOnlyCollection<AudioInfo> AudiosInfo => new ReadOnlyCollection<AudioInfo>(_audiosInfo);

        public AudioSource AudioSource => _audioSource;

        public void Awake()
        {
            Debug.Log(string.Format("{0} musics in list.", _audiosInfo.Count));
            _playing = true;
            _index = START_INDEX;
            _nextTime = ZERO_NEXT_TIME;
            _silence = DEFAULT_SILENCE;
            Played += ListenPlay;
            Paused += ListenPause;
            Resumed += ListenResume;
            Stopped += ListenStop;
            Skipped += ListenSkip;
        }

        public void Start()
        {
            IDayScript script = Object.FindObjectOfType<DayScript>();
            script.Day.SecondPassed += ListenDay;
        }

        public void Update()
        {
            if (!_playing)
                return;
            _nextTime -= Time.deltaTime;
            if (_nextTime > 0f)
                return;
            _silence -= Time.deltaTime;
            if (_silence > 0f)
                return;
            Play();
        }

        public void Play()
        {
            if (!_loop)
                _index = (_index + 1) % _audiosInfo.Count;
            AudioInfo audioInfo = _audiosInfo[_index];
            if (_day < audioInfo.DayStart.RoundedDay || _day > audioInfo.DayEnd.RoundedDay)
            {
                Skip();
                return;
            }
            _nextTime = audioInfo.AudioClip.length;
            _silence = audioInfo.Silence;
            _loop = audioInfo.Loop;
            AudioSource.clip = audioInfo.AudioClip;
            AudioSource.Play();
            _playing = true;
            OnPlay(new AudioPlayerInfo(audioInfo));
        }

        public void Pause()
        {
            _playing = false;
            AudioSource.Pause();
            AudioInfo audioInfo = _audiosInfo[_index];
            OnPause(new AudioPlayerInfo(audioInfo));
        }

        public void Resume()
        {
            _playing = true;
            AudioSource.Play();
            AudioInfo audioInfo = _audiosInfo[_index];
            OnResume(new AudioPlayerInfo(audioInfo));
        }

        public void Stop()
        {
            AudioSource.Stop();
            AudioSource.clip = null;
            AudioInfo audioInfo = _audiosInfo[_index];
            _index = START_INDEX;
            _nextTime = ZERO_NEXT_TIME;
            _silence = DEFAULT_SILENCE;
            _loop = false;
            OnStop(new AudioPlayerInfo(audioInfo));
        }

        public void Skip()
        {
            AudioInfo audioInfo = _audiosInfo[_index];
            AudioSource.Stop();
            AudioSource.clip = null;
            _index = (_index + 1) % _audiosInfo.Count;
            _nextTime = ZERO_NEXT_TIME;
            _silence = DEFAULT_SILENCE;
            _loop = false;
            OnSkip(new AudioPlayerInfo(audioInfo));
        }

        public void OnPlay(AudioPlayerInfo info)
        {
            Played?.Invoke(info);
        }

        public void OnPause(AudioPlayerInfo info)
        {
            Paused?.Invoke(info);
        }

        public void OnResume(AudioPlayerInfo info)
        {
            Resumed?.Invoke(info);
        }

        public void OnStop(AudioPlayerInfo info)
        {
            Stopped?.Invoke(info);
        }

        public void OnSkip(AudioPlayerInfo info)
        {
            Skipped?.Invoke(info);
        }

        public void ListenDay(DayInfo info)
        {
            _day = info.RoundedDay;
        }

        public void ListenPlay(AudioPlayerInfo info)
        {
            Debug.Log(string.Format("Playing: {0}", info.AudioInfo.Name));
        }

        public void ListenPause(AudioPlayerInfo info)
        {
            Debug.Log(string.Format("Paused: {0}", info.AudioInfo.Name));
        }

        public void ListenResume(AudioPlayerInfo info)
        {
            Debug.Log(string.Format("Resumed: {0}", info.AudioInfo.Name));
        }

        public void ListenStop(AudioPlayerInfo info)
        {
            Debug.Log(string.Format("Stopped: {0}", info.AudioInfo.Name));
        }

        public void ListenSkip(AudioPlayerInfo info)
        {
            Debug.Log(string.Format("Skipped: {0}", info.AudioInfo.Name));
        }
    }
}