using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;
using Assets.Components.Pressable;
using Assets.Model;
using Assets.Model.Bio;
using Assets.Model.Controllers;

namespace Assets.Components.Model.Controllable
{
    public class PlayerBluComponent : MonoBehaviour,
        IModelComponent,
        IControllableComponent
    {
        private IAct _keyboardController;
        private IAct _guiController;
        private Human _blu;

        public IModel Model => _blu;

        public ReadOnlyCollection<IAct> Controllers
        {
            get
            {
                List<IAct> controllers = new List<IAct>();
                controllers.Add(_keyboardController);
                controllers.Add(_guiController);
                return new ReadOnlyCollection<IAct>(controllers);
            }
        }

        private void Awake()
        {
            _blu = new Human(transform);
            _blu.Speed.X = 1.7523f;
            _keyboardController = new KeyboardController();

            // here the model will listen another model: human listen the keyboard
            _keyboardController.Acted += _blu.ReceiveOrder;
        }

        private void Start()
        {
            // here the model will listen another model: human listen the GUI
            _guiController = new GUIController(
                FindObjectOfType<BackButtonComponent>(),
                FindObjectOfType<ForwardButtonComponent>(),
                FindObjectOfType<UseButtonComponent>()
            );
            (_guiController as GUIController).Overriden += (_keyboardController as KeyboardController).ListenGUI;
            _guiController.Acted += _blu.ReceiveOrder;
        }

        private void Update()
        {
            (_keyboardController as KeyboardController).Update();
            _blu.Update();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            _blu.OnCollisionEnter2D(collision);
        }
    }
}