using UnityEngine;
using UnityEngine.EventSystems;
using Assets.Rules;
using Assets.Rules.GUI;

namespace Assets.Scripts.GUI
{
    public class BackButtonScript : MonoBehaviour, 
        IRuleScript,
        IPointerDownHandler,
        IPointerUpHandler
    {
        private IRule _backButton;

        public IRule Rule => _backButton;

        public void OnPointerDown(PointerEventData eventData)
        {
            (_backButton as IButton).Press();
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            (_backButton as IButton).Release();
        }

        private void Awake()
        {
            _backButton = new BackButton(transform);
            _backButton.Awake();
        }

        private void Start()
        {
            _backButton.Start();
        }

        private void Update()
        {
            _backButton.Update();
        }
    }
}