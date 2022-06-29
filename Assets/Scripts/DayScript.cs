using UnityEngine;
using Assets.Rules;

namespace Assets.Scripts
{
    public class DayScript : MonoBehaviour,
        IRuleScript
    {
        private IRule _day;

        public IRule Rule => _day;

        private void Awake()
        {
            _day = new Day(transform);
            _day.Awake();
        }

        private void Start()
        {
            _day.Start();
        }

        private void Update()
        {
            _day.Update();
        }
    }
}