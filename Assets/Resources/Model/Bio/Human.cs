using UnityEngine;

namespace Assets.Resources.Model.Bio
{
    public abstract class Human : Animal,
        IEar,
        INoisier
    {
        private readonly AudioListener _audioListener;
        private readonly AudioSource _audioSource;

        public Human(
            Transform transform,
            XYZValue speed,
            Multiplier x,
            Multiplier y,
            Multiplier z) : 
            base(transform, speed, x, y, z)
        {
            _audioListener = transform.GetComponent<AudioListener>();
            _audioSource = transform.GetComponent<AudioSource>();
        }

        public AudioListener AudioListener => _audioListener;

        public AudioSource AudioSource => _audioSource;
    }
}