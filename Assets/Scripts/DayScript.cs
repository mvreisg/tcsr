using UnityEngine;
using Assets.Rules;

namespace Assets.Scripts
{
    public class DayScript : MonoBehaviour,
        IRuleScript,
        IDayScript
    {
        private IRule _day;

        public IRule Rule => _day;

        public IDay Day => _day as IDay;

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