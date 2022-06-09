using UnityEngine;
using Assets.Model.Belong;

namespace Assets.Components
{
    public class TableComponent : MonoBehaviour
    {
        private Table _table;

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