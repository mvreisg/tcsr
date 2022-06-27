using UnityEngine;
using Assets.Rules;
using Assets.Rules.Bio;

namespace Assets.Scripts.Control
{
    public class PlayerScript : MonoBehaviour,
        IRuleScript
    {
        private IRule _rule;

        public IRule Rule => _rule;
        
        private void Awake()
        {
            _rule = new Human(transform, new XYZValue(2f, 2f, 2f));
            _rule.Awake();
        }

        private void Start()
        {
            _rule.Start();
        }

        private void Update()
        {
            _rule.Update();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            (_rule as IColliderable).OnCollisionEnter2D(collision);
        }
    }
}