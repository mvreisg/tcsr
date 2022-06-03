using System.Collections.Generic;
using UnityEngine;
using Assets.Resources.Model.Belong;

namespace Assets.Resources.Model.Bio
{
    public class Human : Animal,
        IEar,
        INoisier,
        IBoxCollider2D
    {
        private readonly AudioListener _audioListener;
        private readonly AudioSource _audioSource;
        private readonly BoxCollider2D _boxCollider2D;
        private readonly List<Belonging> _belongings;
        private bool _isMovingThroughClickingTouchingGUI;

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
            _belongings = new List<Belonging>();
        }

        public AudioListener AudioListener => _audioListener;

        public AudioSource AudioSource => _audioSource;

        public BoxCollider2D BoxCollider2D => _boxCollider2D;

        public override void Do()
        {
            if (!_isMovingThroughClickingTouchingGUI)
                AxisMoveCheck();
            base.Do();
        }

        private void AxisMoveCheck()
        {
            float horizontal = Input.GetAxisRaw("Horizontal");
            if (horizontal < 0f)
                MoveBackX();
            else if (horizontal > 0f)
                MoveForwardX();
            else
                StopX();
        }

        public void IsMovingThroughClickingTouchingGUI(bool reality)
        {
            _isMovingThroughClickingTouchingGUI = reality;
        }

        public void StopX()
        {
            X = Multiplier.ZERO;
        }

        public void MoveBackX()
        {
            X = Multiplier.NEGATIVE;
            SpriteRenderer.flipX = true;
        }

        public void MoveForwardX()
        {
            X = Multiplier.POSITIVE;
            SpriteRenderer.flipX = false;
        }
    }
}