using UnityEngine;
using Assets.Resources.Model;
using Assets.Resources.Model.Bio;

namespace Assets.Resources.Component
{
    public class HumanComponent : MonoBehaviour
    {
        private Human _human;

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