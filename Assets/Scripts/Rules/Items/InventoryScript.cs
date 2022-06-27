using UnityEngine;
using Assets.Rules;
using Assets.Rules.Items;

namespace Assets.Scripts.Rules.Items
{
    public class InventoryScript : MonoBehaviour,
        IRuleScript
    {
        private Inventory _inventory;

        public IRule Rule => _inventory;

        private void Awake()
        {
            _inventory = new Inventory(transform);
            _inventory.Awake();
        }

        private void Start()
        {
            _inventory.Start();
        }

        private void Update()
        {
            _inventory.Update();
        }
    }
}