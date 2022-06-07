using UnityEngine;
using Assets.Resources.Model;
using Assets.Resources.Model.Controllers;
using Assets.Resources.Model.Bio;

namespace Assets.Resources.Components
{
    public class HumanComponent : MonoBehaviour
    {
        private KeyboardController _keyboardController;
        private GUIController _guiController;
        private Human _human;                          

        public Human Human => _human;

        private void Awake()
        {
            _human = new Human(
                transform,
                new XYZValue(1f, 0f, 0f),
                Multiplier.ZERO,
                Multiplier.ZERO,
                Multiplier.ZERO,
                new Vector3(0f, 0f, 0f)
            );
        }

        private void Start()
        {
            _keyboardController = new KeyboardController(transform, true);
            _keyboardController.Acted += _human.ListenPlayerAction;
            _guiController = new GUIController(
                transform, 
                true, 
                FindObjectOfType<BackButtonComponent>(),
                FindObjectOfType<ForwardButtonComponent>()
            );
            _guiController.Acted += _human.ListenPlayerAction;
        }

        private void Update()
        {
            _keyboardController.Do();
            _guiController.Do();
            _human.Do();
        }
    }
}