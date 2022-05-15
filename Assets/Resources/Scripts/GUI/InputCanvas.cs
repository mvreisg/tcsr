using System.Collections.Generic;
using UnityEngine;
using Assets.Resources.Scripts.Character;
using Assets.Resources.Scripts.Tag;

namespace Assets.Resources.Scripts.GUI
{
    public class InputCanvas : MonoBehaviour
    {
        private Blu _blu;

        private const string BACK_BUTTON_NAME = "back_button";
        private const string FORWARD_BUTTON_NAME = "forward_button";
        private const string USE_BELONGING_BUTTON_NAME = "use_belonging_button";

        private Dictionary<string, GameObject> _buttons;

        private void Awake()
        {
            _buttons = new Dictionary<string, GameObject>();
        }

        private void Start()
        {
            _blu = FindObjectOfType<Blu>();
            _buttons.Add(BACK_BUTTON_NAME, transform.Find(BACK_BUTTON_NAME).gameObject);
            _buttons.Add(FORWARD_BUTTON_NAME, transform.Find(FORWARD_BUTTON_NAME).gameObject);
            _buttons.Add(USE_BELONGING_BUTTON_NAME, transform.Find(USE_BELONGING_BUTTON_NAME).gameObject);
            _buttons[USE_BELONGING_BUTTON_NAME].SetActive(false);
        }

        public void ReceivePickUp(GameObject picker, GameObject picked)
        {
            bool correspondsToTheControlledPlayer = picker.Equals(_blu.gameObject);
            if (!correspondsToTheControlledPlayer)
                return;

            if (!_buttons[USE_BELONGING_BUTTON_NAME].activeSelf && picked.CompareTag(TagManager.BOOK))
                _buttons[USE_BELONGING_BUTTON_NAME].SetActive(true);
        }

        public void ReceiveDestroy(GameObject brinkToDestruction)
        {
            if (brinkToDestruction.CompareTag(TagManager.BOOK))
                _buttons[USE_BELONGING_BUTTON_NAME].SetActive(false);
        }
    }
}