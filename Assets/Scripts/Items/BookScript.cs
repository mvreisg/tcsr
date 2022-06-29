using UnityEngine;
using Assets.Rules;
using Assets.Rules.Items;

namespace Assets.Scripts.Items
{
    public class BookScript : MonoBehaviour,
        IRuleScript
    {
        private IRule _book;

        public IRule Rule => _book;

        private void Awake()
        {
            _book = new Book(transform);
            _book.Awake();
        }

        private void Start()
        {
            _book.Start();
        }

        private void Update()
        {
            _book.Update();
        }

        private void FixedUpdate()
        {
            (_book as IPhysics).FixedUpdate();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            (_book as ICollision).OnCollisionEnter2D(collision);
        }

        private void OnTriggerEnter2D(Collider2D collider)
        {
            (_book as ITrigger).OnTriggerEnter2D(collider);
        }
    }
}