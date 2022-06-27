using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;
using Assets.Rules;
using Assets.Rules.Bio;
using Assets.Rules.Control;
using Assets.Scripts.Pressable;

namespace Assets.Scripts.Rules.Control
{
    public class PlayerBluScript : MonoBehaviour,
        IRuleScript,
        IControlScript
    {
        private IOrder _keyboardController;
        private IOrder _guiController;
        private Human _blu;

        public IRule Rule => _blu;

        public ReadOnlyCollection<IOrder> Controllers
        {
            get
            {
                List<IOrder> controllers = new List<IOrder>();
                controllers.Add(_keyboardController);
                controllers.Add(_guiController);
                return new ReadOnlyCollection<IOrder>(controllers);
            }
        }

        private void Awake()
        {
            _blu = new Human(transform);
            _blu.Speed.X = 1.7523f;
            _keyboardController = new KeyboardController();

            // here the model will listen another model: human listen the keyboard
            _keyboardController.Ordered += _blu.ReceiveOrder;
        }

        private void Start()
        {
            // here the model will listen another model: human listen the GUI
            _guiController = new GUIController(
                FindObjectOfType<BackButtonScript>(),
                FindObjectOfType<ForwardButtonScript>(),
                FindObjectOfType<UseButtonScript>()
            );
            (_guiController as GUIController).Overriden += (_keyboardController as KeyboardController).ListenGUI;
            _guiController.Ordered += _blu.ReceiveOrder;
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