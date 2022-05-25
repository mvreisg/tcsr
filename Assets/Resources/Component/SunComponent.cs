using System;
using UnityEngine;
using Assets.Resources.Model;

namespace Assets.Resources.Component
{
    public class SunComponent : MonoBehaviour
    {
        private Day _day;

        public Day Day => _day;

        private void Awake()
        {
            _day = new Day(transform, new DateTime(DateTime.Now.Year, 5, 25, 0, 0, 0, 0), GameObject.Find("sun").GetComponent<Light>());
        }

        private void Update()
        {
            _day.ShineOnYouCrazyDiamond();
        }
    }
}