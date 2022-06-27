using Assets.Scripts.Rules;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Rules.Items
{
    public class Inventory : 
        IRule
    {
        private readonly Transform _transform;
        private readonly Dictionary<Item, IUsable> _items;

        public Inventory(Transform transform)
        {
            _transform = transform;
            _items = new Dictionary<Item, IUsable>();
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
            (rule as IPicker).Picked += ListenPicking;
        }

        public void Update()
        {
            
        }

        // Class originals

        public void ListenPicking(PickInfo info)
        {
            IUsable picked = info.Picked;
            IUser picker = info.Picker;
            bool added = _items.TryAdd(picked.Type, picked);
            if (!added)
                return;
            picker.Used += picked.ListenUse;
        }
    }
}