using UnityEngine;
using Assets.Rules;
using Assets.Rules.Items;

namespace Assets.Scripts.Items
{
    public class ScytheScript : MonoBehaviour,
        IRuleScript
    {
        private IRule _scythe;

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
            (_scythe as IPhysics).FixedUpdate();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            (_scythe as ICollision).OnCollisionEnter2D(collision);
        }

        private void OnTriggerEnter2D(Collider2D collider)
        {
            (_scythe as ITrigger).OnTriggerEnter2D(collider);
        }
    }
}