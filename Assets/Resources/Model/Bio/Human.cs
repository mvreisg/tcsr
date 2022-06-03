using System.Collections.Generic;
using UnityEngine;
using Assets.Resources.Model.Belong;

namespace Assets.Resources.Model.Bio
{
    public abstract class Human : Animal,
        IEar,
        INoisier
    {
        private readonly AudioListener _audioListener;
        private readonly AudioSource _audioSource;
        private readonly List<Belonging> _belongings;

        public Human(
            Transform transform,
            XYZValue speed,
            Multiplier x,
            Multiplier y,
            Multiplier z,
            Vector3 force) : 
            base(transform, speed, x, y, z, force)
        {
            _audioListener = transform.GetComponent<AudioListener>();
            _audioSource = transform.GetComponent<AudioSource>();
            _belongings = new List<Belonging>();
        }

        public AudioListener AudioListener => _audioListener;

        public AudioSource AudioSource => _audioSource;

        public List<Belonging> Belongings => _belongings;
    }
}