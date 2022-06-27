using UnityEngine;
using Assets.Rules.Items;
using Assets.Rules.GUI;
using Assets.Scripts;
using Assets.Scripts.GUI;

namespace Assets.Rules.Bio
{
    public class Human :
        IRule,
        IAct,
        IMovable,
        IPhysics,
        IColliderable,
        IEar,
        INoisier,
        IRenderable,
        IPicker,
        IUser,
        IButtonListener
    {
        public event IAct.ActEventHandler Acted;
        public event IMovable.MovableEventHandler Moved;
        public event IPicker.PickerEventHandler Picked;
        public event IUser.UserEventHandler Used;

        private readonly Transform _transform;
        private readonly XYZValue _speed;
        private readonly Orientation _orientation;
        private readonly Facing _facing;
        private readonly Rigidbody2D _rigidbody2D;
        private readonly XYZValue _force;
        private readonly AudioListener _audioListener;
        private readonly AudioSource _audioSource;
        private readonly PolygonCollider2D _polygonCollider2D;
        private readonly SpriteRenderer _spriteRenderer;

        private Item _holding;

        public Human(Transform transform, XYZValue speed)
        {
            _transform = transform;
            _speed = speed;
            _orientation = new Orientation();
            _facing = new Facing(Flag.POSITIVE);
            _rigidbody2D = transform.GetComponent<Rigidbody2D>();
            _force = XYZValue.ZERO;
            _audioListener = transform.GetComponent<AudioListener>();
            _audioSource = transform.GetComponent<AudioSource>();
            _polygonCollider2D = transform.GetComponent<PolygonCollider2D>();
            _spriteRenderer = transform.GetComponent<SpriteRenderer>();
        }

        public Transform Transform => _transform;

        public Facing Facing => _facing;

        public XYZValue Speed => _speed;

        public Orientation Orientation => _orientation;

        public Rigidbody2D Rigidbody2D => _rigidbody2D;

        public XYZValue Force => _force;

        public Collider2D Collider2D => _polygonCollider2D;

        public AudioListener AudioListener => _audioListener;

        public AudioSource AudioSource => _audioSource;

        public Renderer Renderer => _spriteRenderer;

        public void Awake()
        {
            
        }

        public void Start()
        {
            ((Object.FindObjectOfType<BackButtonScript>() as IRuleScript).Rule as IButton).StateChanged 
                += ListenButton;
            ((Object.FindObjectOfType<ForwardButtonScript>() as IRuleScript).Rule as IButton).StateChanged 
                += ListenButton;
            ((Object.FindObjectOfType<UseButtonScript>() as IRuleScript).Rule as IButton).StateChanged
                += ListenButton;
        }

        public void Update()
        {
            Move();
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
                    Orientation.X = Flag.ZERO;
                    break;
                case Action.TURN_BACK:
                    Facing.X = Flag.NEGATIVE;
                    break;
                case Action.BACK:
                    Orientation.X = Flag.NEGATIVE;
                    break;
                case Action.TURN_FORWARD:
                    Facing.X = Flag.POSITIVE;
                    break;
                case Action.FORWARD:
                    Orientation.X = Flag.POSITIVE;
                    break;
                case Action.USE:
                    Use();
                    break;
            }
            OnActed(new ActionInfo(this, action, Facing));
        }

        public void Move()
        {
            Flag xFlag = Orientation.X;
            float x;
            switch (xFlag)
            {
                default:
                    throw new UnityException($"unhandled state: {xFlag}");
                case Flag.NEGATIVE:
                    x = -1f;
                    (Renderer as SpriteRenderer).flipX = true;
                    break;
                case Flag.ZERO:
                    x = 0f;
                    break;
                case Flag.POSITIVE:
                    x = 1f;
                    (Renderer as SpriteRenderer).flipX = false;
                    break;
            }

            float sx = x * Speed.X;
            Transform.Translate(Time.deltaTime * new Vector3(sx, 0f, 0f));
            OnMoved();
        }

        public void Use()
        {
            OnUsed();
        }

        public void Pick(PickInfo info)
        {
            OnPicked(info);
        }

        public void FixedUpdate()
        {

        }

        public void OnCollisionEnter2D(Collision2D collision)
        {
            IRuleScript component = collision.collider.GetComponent<IRuleScript>();
            if (component is null)
                return;

            IRule rule = component.Rule;
            if (rule is not IUsable)
                return;

            IUsable usable = rule as IUsable;
            Pick(new PickInfo(this, usable));
        }

        public void OnTriggerEnter2D(Collider2D collider)
        {
            Debug.Log(string.Format("{0} passed through {1}", collider.name, Transform.name));
        }

        public void ListenButton(ButtonInfo info)
        {
            Buttons button = info.Button;
            bool pressed = info.Pressed;
            switch (button)
            {
                default:
                    throw new UnityException(string.Format("unahndled state: {0}", button));
                case Buttons.BACK:
                    if (pressed)
                    {
                        Act(Action.TURN_BACK);
                        Act(Action.BACK);
                    }
                    else
                    {
                        Act(Action.STOP);
                        Act(Action.IDLE);
                    }
                    break;
                case Buttons.FORWARD:
                    if (pressed)
                    {
                        Act(Action.TURN_FORWARD);
                        Act(Action.FORWARD);
                    }
                    else
                    {
                        Act(Action.STOP);
                        Act(Action.IDLE);
                    }
                    break;
                case Buttons.USE:
                    Act(Action.USE);
                    break;
                case Buttons.INVENTORY:
                    break;
            }
        }

        public void OnActed(ActionInfo info)
        {
            Acted?.Invoke(info);
        }

        public void OnMoved()
        {
            Moved?.Invoke(new MovementInfo(this, Transform.position));
        }

        public void OnPicked(PickInfo info)
        {
            Picked?.Invoke(info);
        }

        public void OnUsed()
        {
            Used?.Invoke(new UseInfo(this, _holding));
        }
    }
}