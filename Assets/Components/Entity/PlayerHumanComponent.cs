using UnityEngine;
using Assets.Components.Pressable;
using Assets.Model;
using Assets.Model.Bio;
using Assets.Model.Controllers;

namespace Assets.Components.Entity
{
    public class PlayerHumanComponent : MonoBehaviour,
        IEntityComponent
    {
        private IAct _keyboardController;
        private Human _human;                          

        public IEntity Entity => _human;

        private void Awake()
        {
            _human = new Human(transform);
            _human.Speed.X = 1.23f;
            _keyboardController = new KeyboardController();
        }

        private void Start()
        {
            new GUIController(
                FindObjectOfType<BackButtonComponent>(),
                FindObjectOfType<ForwardButtonComponent>()
            );
        }

        private void Update()
        {
            (_keyboardController as KeyboardController).Update();
            _human.Exist();
        }
    }
}