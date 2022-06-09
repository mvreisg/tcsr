using UnityEngine;
using Assets.Model;
using Assets.Model.Bio;
using Assets.Model.Controllers;

namespace Assets.Components
{
    public class PlayerHumanComponent : MonoBehaviour
    {
        private KeyboardController _keyboardController;
        private GUIController _guiController;
        private Human _human;                          

        public IEntity Human => _human;

        private void Awake()
        {
            _human = new Human(transform);
            _human.Speed.X = 1.23f;
            _keyboardController = new KeyboardController(transform);
            _keyboardController.Acted += _human.ListenPlayerAction;
        }

        private void Start()
        {
            _guiController = new GUIController(
                transform,
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