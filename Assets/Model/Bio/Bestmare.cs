using UnityEngine;
using Assets.Model.Controllers;

namespace Assets.Model.Bio
{
    public class Bestmare : LivingBeing,
        IRigidbody2D,
        ICapsuleCollider2D,
        INoisier,
        ISpriteRenderer
    {
        public delegate void BestmareEventHandler(Vector3 me, Vector3 target);
        public event BestmareEventHandler ReadyToPursue;

        private readonly Rigidbody2D _rigidbody2D;
        private Vector3 _force;
        private readonly CapsuleCollider2D _capsuleCollider2D;
        private readonly AudioSource _audioSource;
        private readonly SpriteRenderer _spriteRenderer;

        private Vector3 _target;

        public Bestmare(Transform transform) : base(transform)
        {
            _force = Vector3.zero;
            _rigidbody2D = transform.GetComponent<Rigidbody2D>();
            _capsuleCollider2D = transform.GetComponent<CapsuleCollider2D>();
            _audioSource = transform.GetComponent<AudioSource>();
            _spriteRenderer = transform.GetComponent<SpriteRenderer>();
        }

        public Rigidbody2D Rigidbody2D => _rigidbody2D;

        public Vector3 Force => _force;

        public CapsuleCollider2D CapsuleCollider2D => _capsuleCollider2D;

        public AudioSource AudioSource => _audioSource;

        public SpriteRenderer SpriteRenderer => _spriteRenderer;

        public void FixedPhysics()
        {
            Debug.Log("BestmareFixedPhysics...");
            //_rigidbody2D.AddForce(Force);
        }

        public override void Do()
        {
            OnReadyToPursue(Transform.position, _target);
            Move();
        }

        public override void Stop()
        {
            base.Stop();
        }

        public override void TurnBack()
        {
            base.TurnBack();
            SpriteRenderer.flipX = true;
        }

        public override void TurnForward()
        {
            base.TurnForward();
            SpriteRenderer.flipX = false;
        }

        public void ListenEntityReposition(Vector3 position)
        {
            if (_target.magnitude >= position.magnitude)
                return;
            _target = position;
        }

        public void ListenEntityCreation(IEntity created)
        {
            if (created is Human)
                created.Repositioned += ListenEntityReposition;
        }

        public void ListenEntityDestruction(IEntity destroyed)
        {
            if (destroyed is Human)
                destroyed.Repositioned -= ListenEntityReposition;
        }

        public void Act(Action action)
        {
            switch (action)
            {
                default:
                    throw new UnityException($"unhandled state: {action}");
                case Action.IDLE:
                    break;
                case Action.STOP:
                    Stop();
                    break;
                case Action.BACK:
                    TurnBack();
                    break;
                case Action.FORWARD:
                    TurnForward();
                    break;
                case Action.USE:
                    break;
            }
        }

        private void OnReadyToPursue(Vector3 me, Vector3 target)
        {
            ReadyToPursue?.Invoke(me, target);
        }
    }
}