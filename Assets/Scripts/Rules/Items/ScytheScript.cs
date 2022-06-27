using Assets.Rules;
using UnityEngine;
using Assets.Rules.Items;

namespace Assets.Scripts.Rules.Items
{
    public class ScytheScript : MonoBehaviour,
        IRuleScript
    {
        private Scythe _scythe;

        public IRule Rule => _scythe;

        private void Awake()
        {
            _scythe = new Scythe(transform);
            _scythe.Awake();
        }

        private void Start()
        {
            _scythe.Start();
        }

        private void Update()
        {
            _scythe.Update();
        }

        private void FixedUpdate()
        {
            _scythe.FixedUpdate();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            _scythe.OnCollisionEnter2D(collision);
        }

        private void OnTriggerEnter2D(Collider2D collider)
        {
            _scythe.OnTriggerEnter2D(collider);
        }
    }
}