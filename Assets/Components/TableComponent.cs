using UnityEngine;
using Assets.Model;
using Assets.Model.Belong;

namespace Assets.Components
{
    public class TableComponent : MonoBehaviour,
        IEntityComponent
    {
        private Table _table;

        public IEntity Entity => _table;

        private void Awake()
        {
            _table = new Table(transform);
        }

        private void Update()
        {
            _table.Do();
        }
    }
}