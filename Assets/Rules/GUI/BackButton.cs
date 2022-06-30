using UnityEngine;

namespace Assets.Rules.GUI
{
    public class BackButton :
        IRule,
        IButton
    {
        public event IButton.ButtonEventHandler StateChanged;

        private readonly Transform _transform;

        public BackButton(Transform transform)
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
            OnStateChanged(new ButtonInfo(Buttons.BACK, true));
        }

        public void Release()
        {
            OnStateChanged(new ButtonInfo(Buttons.BACK, false));
        }

        public void OnStateChanged(ButtonInfo info)
        {
            StateChanged?.Invoke(info);
        }
    }
}