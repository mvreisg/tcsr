using UnityEngine;

namespace Assets.Resources.Model.Bio
{
    public class Human : LivingBeing,
        IEar,
        INoisier,
        IBoxCollider2D
    {
        private readonly AudioListener _audioListener;
        private readonly AudioSource _audioSource;
        private readonly BoxCollider2D _boxCollider2D;

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
            _boxCollider2D = transform.GetComponent<BoxCollider2D>();
        }

        public AudioListener AudioListener => _audioListener;

        public AudioSource AudioSource => _audioSource;

        public BoxCollider2D BoxCollider2D => _boxCollider2D;

        public override void Do()
        {
            base.Do();
        }
    }
}