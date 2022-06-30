using UnityEngine;
using UnityEngine.EventSystems;
using Assets.Rules;
using Assets.Rules.GUI;

namespace Assets.Scripts.GUI
{
    public class ForwardButtonScript : MonoBehaviour,
        IRuleScript,
        IForwardButtonScript,
        IPointerDownHandler,
        IPointerUpHandler
    {
        private IRule _forwardButton;

        public IRule Rule => _forwardButton;

        public IButton Button => _forwardButton as IButton;

        public void OnPointerDown(PointerEventData eventData)
        {
            (_forwardButton as IButton).Press();
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            (_forwardButton as IButton).Release();
        }

        private void Awake()
        {
            _forwardButton = new ForwardButton(transform);
            _forwardButton.Awake();
        }

        private void Start()
        {
            _forwardButton.Start();
        }

        private void Update()
        {
            _forwardButton.Update();
        }
    }
}