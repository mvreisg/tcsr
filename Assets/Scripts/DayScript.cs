using UnityEngine;
using Assets.Rules;
using Assets.Rules.Items;

namespace Assets.Scripts
{
    public class DayScript : MonoBehaviour,
        IRuleScript
    {
        private Day _clock;

        public IRule Rule => _clock;

        private void Awake()
        {
            _clock = new Day(transform);
            _clock.Awake();
        }

        private void Start()
        {
            _clock.Start();
        }

        private void Update()
        {
            _clock.Update();
        }
    }
}