using UnityEngine;
using Assets.Resources.Model;
using Assets.Resources.Model.Bio;

namespace Assets.Resources.Components
{
    public class BluComponent : MonoBehaviour
    {
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
            BackButtonComponent backButtonComponent = FindObjectOfType<BackButtonComponent>();
            backButtonComponent.Down += MoveBackX;
            backButtonComponent.Up += StopX;

            ForwardButtonComponent forwardButtonComponent = FindObjectOfType<ForwardButtonComponent>();
            forwardButtonComponent.Down += MoveForwardX;
            forwardButtonComponent.Up += StopX;
        }

        private void Update()
        {
            _human.Do();
        }

        public void StopX()
        {
            _human.IsMovingThroughClickingTouchingGUI(false);
            _human.StopX();
        }

        public void MoveBackX()
        {
            _human.IsMovingThroughClickingTouchingGUI(true);
            _human.MoveBackX();
        }

        public void MoveForwardX()
        {
            _human.IsMovingThroughClickingTouchingGUI(true);
            _human.MoveForwardX();
        }
    }
}