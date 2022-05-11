using System.Collections.Generic;
using UnityEngine;
using Assets.Resources.Scripts.Belongings;
using Assets.Resources.Scripts.Characters;
using Assets.Resources.Scripts.Creatures;

public class Bestmare : MonoBehaviour, IPersecutorCreature
{
    private enum Vision
    {
        NORMAL,
        ALTERED
    }

    public delegate void DestroyDelegate(GameObject gameObject);

    public event DestroyDelegate OnDestroy;

    public bool CanPersecute { get; private set; }

    private Blu _blu;

    private SpriteRenderer _spriteRenderer;

    private float _speed;

    [SerializeField]
    private List<Sprite> _sprites;

    private Vision _vision;

    private float _nextChangeTime;

    public float NextChangeTime
    {
        get
        {
            switch (_vision)
            {
                case Vision.NORMAL:
                    return Random.Range(1f, Mathf.PI);
                case Vision.ALTERED:
                    return Random.Range(.15f, .3f);
                default:
                    throw new UnityException($"unhandled state: {_vision}");
            }
        }
    }

    private Bestmare() : base()
    {
        CanPersecute = true;
        _speed = 1.5f;
        _vision = Vision.NORMAL;
    }

    private void Awake()
    {
        _nextChangeTime = NextChangeTime;
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        _blu = FindObjectOfType<Blu>();
    }

    private void Update()
    {
        TimeConsumer();
        MoveTowards();
    }

    public void MoveTowards()
    {
        if (!CanPersecute)
            return;
        float x = transform.position.x;
        float min = Mathf.Min(x, _blu.transform.position.x);
        int xDirection = min == x ? 1 : -1;
        FlipSprite(xDirection == -1);
        transform.Translate(Time.deltaTime * Vector2.right * xDirection * _speed);
    }

    private void TimeConsumer()
    {
        _nextChangeTime -= Time.deltaTime;
        if (_nextChangeTime <= 0f)
        {
            SetSprite(_vision);
            _nextChangeTime = NextChangeTime;
        }
    }

    private void FlipSprite(bool flip)
    {
        _spriteRenderer.flipX = flip;
    }

    private void SetSprite(Vision vision)
    {
        int index = -1;
        switch (vision)
        {
            case Vision.NORMAL:
                _vision = Vision.ALTERED;
                index = 1;
                break;
            case Vision.ALTERED:
                _vision = Vision.NORMAL;
                index = 0;
                break;
            default:
                throw new UnityException($"unhandled state: {_vision}");
        }
        _spriteRenderer.sprite = _sprites[index];
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        CanPersecute = !collision.gameObject.Equals(_blu.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.GetComponent<Diary>() != null)
        {
            OnDestroy?.Invoke(gameObject);
            Destroy(gameObject);
        }
    }
}
