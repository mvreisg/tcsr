using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;

namespace Assets.Rules.Items
{
    public class Inventory : 
        IRule,
        IPickerListener
    {
        private readonly Transform _transform;
        private readonly Dictionary<ItemTypes, IUsable> _items;

        public Inventory(Transform transform)
        {
            _transform = transform;
            _items = new Dictionary<ItemTypes, IUsable>();
        }

        public Transform Transform => _transform;

        public void Awake()
        {
            
        }

        public void Start()
        {
            IRule rule = Transform.parent.GetComponent<IRuleScript>().Rule;
            if (rule is not IPicker)
                throw new UnityException(string.Format("{0} is not {1}", rule.Transform.name, typeof(IPicker)));
            (rule as IPicker).Picked += ListenPicker;
        }

        public void Update()
        {
            
        }

        public void ListenPicker(PickInfo info)
        {
            IUsable picked = info.Picked;
            IUse picker = info.Picker;
            bool added = _items.TryAdd(picked.Type, picked);
            if (!added)
                return;
            picker.Used += (picked as IUseListener).ListenUse;
        }
    }
}