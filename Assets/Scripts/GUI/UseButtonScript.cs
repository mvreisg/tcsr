using UnityEngine;
using UnityEngine.EventSystems;
using Assets.Rules;
using Assets.Rules.GUI;

namespace Assets.Scripts.GUI
{
    public class UseButtonScript : MonoBehaviour,
        IRuleScript,
        IButtonScript,
        IPointerDownHandler,
        IPointerUpHandler
    {
        private IRule _useButton;

        public IRule Rule => _useButton;

        public IButton Button => _useButton as IButton;

        public void OnPointerDown(PointerEventData eventData)
        {
            (_useButton as IButton).Press();
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            (_useButton as IButton).Release();
        }

        private void Awake()
        {
            _useButton = new UseButton(transform);
            _useButton.Awake();
        }

        private void Start()
        {
            _useButton.Start();
        }

        private void Update()
        {
            _useButton.Update();
        }
    }
}