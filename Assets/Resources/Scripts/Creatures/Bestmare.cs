using UnityEngine;
using Assets.Resources.Scripts.Characters;
using Assets.Resources.Scripts.Creatures;
using System.Collections.Generic;

public class Bestmare : MonoBehaviour, IAggressiveCreature
{
    public Blu Blu { get; private set; }

    public SpriteRenderer SpriteRenderer { get; private set; }

    public float Speed => 1.5f;

    public bool CanMove { get; private set; }

    [SerializeField]
    private List<Sprite> _doubles;

    private int _spriteIndex;

    public float NextChangeTime
    {
        get
        {
            if (_spriteIndex == 0)
            {
                return Random.Range(1f, Mathf.PI);
            }
            else
            {
                return Random.Range(.15f, .3f);
            }
        }
    }

    private float _nextChangeTime;

    private void Awake()
    {
        _spriteIndex = 0;
        CanMove = true;
        SpriteRenderer = GetComponent<SpriteRenderer>();
        SpriteRenderer.sprite = _doubles[_spriteIndex];
        _nextChangeTime = NextChangeTime;
    }

    private void Start()
    {
        Blu = FindObjectOfType<Blu>();
    }

    private void Update()
    {
        _nextChangeTime -= Time.deltaTime;
        if (_nextChangeTime <= 0f)
        {
            SwapSprite();
            _nextChangeTime = NextChangeTime;
        }
        if (CanMove)
            MoveTowards();
    }

    public void MoveTowards()
    {
        float x = transform.position.x;
        float min = Mathf.Min(x, Blu.transform.position.x);
        int xDirection = min == x ? 1 : -1;
        SpriteRenderer.flipX = xDirection == 1;
        transform.Translate(Time.deltaTime * Vector2.right * xDirection * Speed);
    }

    private void SwapSprite()
    {
        if (_spriteIndex == 0)
        {
            _spriteIndex++;
        }
        else
        {
            _spriteIndex = 0;
        }

        SpriteRenderer.sprite = _doubles[_spriteIndex];
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        CanMove = !(collision.gameObject.Equals(Blu.gameObject));
    }
}
