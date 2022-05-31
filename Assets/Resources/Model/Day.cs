using UnityEngine;

namespace Assets.Resources.Models
{
    public class Day : Entity
    {
        private int _hours;
        private int _minutes;
        private int _seconds;

        public int Hours => _hours;
        public int Minutes => _minutes;
        public int Seconds => _seconds;

        public Day(Transform transform, int hours, int minutes, int seconds) : base(transform)
        {
            _hours = hours;
            _minutes = minutes;
            _seconds = seconds;
        }

        public override void Do()
        {
            Debug.Log(string.Format("%02d:%02d:%02d", Hours, Minutes, Seconds));
        }
    }
}