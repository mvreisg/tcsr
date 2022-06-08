using UnityEngine;
using Assets.Resources.Model.Belong;

namespace Assets.Resources.Components
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