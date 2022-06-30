using System;
using UnityEngine;

namespace Assets.Rules.Audio
{
    [Serializable]
    public class AudioInfo
    {
        [SerializeField]
        private string _name;

        [SerializeField]
        private AudioClip _audioClip;

        [SerializeField]
        private float _silence;

        [SerializeField]
        private bool _loop;

        [SerializeField]
        private DayInfo _dayStart;

        [SerializeField]
        private DayInfo _dayEnd;

        public string Name => _name;

        public AudioClip AudioClip => _audioClip;

        public float Silence => _silence;

        public bool Loop => _loop;

        public DayInfo DayStart => _dayStart;

        public DayInfo DayEnd => _dayEnd;
    }
}