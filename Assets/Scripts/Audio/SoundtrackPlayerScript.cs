using System.Collections.Generic;
using UnityEngine;
using Assets.Rules;
using Assets.Rules.Audio;

namespace Assets.Scripts.Audio
{
    public class SoundtrackPlayerScript : MonoBehaviour,
        IRuleScript
    {
        private IAudioPlayer _audioPlayer;

        public IRule Rule => _audioPlayer as IRule;

        [SerializeField]
        private List<AudioInfo> _audiosInfo;

        private void Awake()
        {
            _audioPlayer = new AudioPlayer(transform, _audiosInfo);
            (_audioPlayer as IRule).Awake();
        }

        private void Start()
        {
            (_audioPlayer as IRule).Start();
        }

        private void Update()
        {
            (_audioPlayer as IRule).Update();
        }
    }
}