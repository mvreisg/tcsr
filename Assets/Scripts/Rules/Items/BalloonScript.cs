using UnityEngine;
using Assets.Rules;
using Assets.Rules.Items;

namespace Assets.Scripts.Rules.Items
{
    public class BalloonScript : MonoBehaviour,
        IRuleScript
    {
        private Balloon _balloon;

        public IRule Rule => _balloon;

        private void Awake()
        {
            _balloon = new Balloon(transform);
            _balloon.Awake();
        }

        private void Start()
        {
            _balloon.Start();
        }

        private void Update()
        {
            _balloon.Update();
        }

        private void FixedUpdate()
        {
            _balloon.FixedUpdate();
        }
    }
}