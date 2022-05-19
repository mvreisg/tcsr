using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Assets.Resources.Pure;
using Assets.Resources.Components.Belongings;
using Assets.Resources.Components.Character;

namespace Assets.Resources.Components.GUI.Use
{
    public class UseButtonEventTrigger : EventTrigger
    {
        private const string INATE_POWER = "inate_power";
        private const string BOOK_SHEET = "book_sheet";

        private bool _enabled;

        private Image _image;
        private Button _button;

        private IUsable _usable;

        private readonly Dictionary<IUsable.Type, Sprite> _sprites = new Dictionary<IUsable.Type, Sprite>();

        private void Awake()
        {
            foreach (Sprite sprite in UnityEngine.Resources.LoadAll<Sprite>("Images/Sprites/Belongings/belongings/"))
            {
                switch (sprite.name)
                {
                    case INATE_POWER:
                        _sprites.Add(IUsable.Type.INATE_POWER, sprite);
                        break;
                    case BOOK_SHEET:
                        _sprites.Add(IUsable.Type.BOOK, sprite);
                        break;
                    default:
                        throw new UnityException($"unknown sprite: {sprite.name}");
                }
            }
            _image = GetComponent<Image>();
            _button = GetComponent<Button>();
            _enabled = false;
            _image.enabled = _enabled;
            _button.enabled = _enabled;
        }

        private void Start()
        {
            GameObject.FindGameObjectWithTag(Tag.BLU).GetComponent<Blu>().SelectUsable += SetUsable;
        }

        private void SetUsable(IUsable usable)
        {
            _usable = usable;
            _enabled = _usable != null;
            _image.enabled = _enabled;
            _button.enabled = _enabled;
            _image.sprite = _sprites[_usable.TypeOf];
        }

        public override void OnPointerDown(PointerEventData eventData)
        {
            if (!_enabled)
                return;

            _usable?.AllowUse();
            base.OnPointerDown(eventData);
        }

        public override void OnPointerUp(PointerEventData eventData)
        {
            if (!_enabled)
                return;

            _usable?.ForbidUse();
            base.OnPointerUp(eventData);
        }
    }
}