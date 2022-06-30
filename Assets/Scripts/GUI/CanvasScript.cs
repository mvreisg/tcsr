using Assets.Rules;
using Assets.Rules.GUI;
using UnityEngine;

namespace Assets.Scripts.GUI
{
    public class CanvasScript : MonoBehaviour,
        IRuleScript,
        ICanvasScript
    {
        private IRule _canvas;

        public IRule Rule => _canvas;

        public ICanvas Canvas => _canvas as ICanvas;

        private void Awake()
        {
            _canvas = new Rules.GUI.Canvas(transform);
            _canvas.Awake();
        }

        private void Start()
        {
            _canvas.Start();
        }

        private void Update()
        {
            _canvas.Update();
        }
    }
}