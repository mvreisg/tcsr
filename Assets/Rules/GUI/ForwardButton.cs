using UnityEngine;

namespace Assets.Rules.GUI
{
    public class ForwardButton :
        IRule,
        IButton
    {
        public event IButton.ButtonEventHandler StateChanged;

        private readonly Transform _transform;

        public ForwardButton(Transform transform)
        {
            _transform = transform;
        }

        public Transform Transform => _transform;

        public void Awake()
        {

        }

        public void Start()
        {

        }

        public void Update()
        {

        }

        public void Press()
        {
            OnStateChanged(new ButtonInfo(Buttons.FORWARD, true));
        }

        public void Release()
        {
            OnStateChanged(new ButtonInfo(Buttons.FORWARD, false));
        }

        public void OnStateChanged(ButtonInfo info)
        {
            StateChanged?.Invoke(info);
        }
    }
}