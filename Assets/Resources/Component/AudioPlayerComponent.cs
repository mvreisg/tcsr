using System;
using UnityEngine;
using Assets.Resources.Model;

namespace Assets.Resources.Component
{
    public class AudioPlayerComponent : MonoBehaviour
    {
        [SerializeField]
        private AudioClip _clip;

        private AudioSource _player;

        private Day _day;

        private SunComponent _sunComponent;

        private void Start()
        {
            _sunComponent = FindObjectOfType<SunComponent>();
            _day = _sunComponent.Day;
            Day.State state = _day.NowIs;
            switch (state)
            {
                case Day.State.MORNING:
                case Day.State.AFTERNOON:
                    _player = FindObjectOfType<AudioSource>();
                    _player.clip = _clip;
                    _player.Play();
                    return;
                default:
                    return;
            }
        }
    }
}