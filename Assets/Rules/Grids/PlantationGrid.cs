using UnityEngine;
using UnityEngine.Tilemaps;
using Assets.Rules.Items;

namespace Assets.Rules.Grids
{
    public class PlantationGrid : 
        IRule
    {
        private readonly Transform _transform;
        private readonly Tilemap _tilemap;

        public PlantationGrid(Transform transform)
        {
            _transform = transform;
            _tilemap = transform.GetComponent<Tilemap>();
        }

        public Transform Transform => _transform;

        public void Awake()
        {
            Vector3Int size = _tilemap.cellBounds.size;
            Debug.LogFormat(
                "{0} plantation grid size: [x:{1}, y:{2}, z:{3}]",
                Transform.name,
                size.x,
                size.y,
                size.z
            );
        }

        public void Start()
        {
            
        }

        public void Update()
        {
            
        }

        // Class originals

        public void ListenScytheUse(UsableInfo info)
        {
            if (!info.Used.Type.Equals(Item.SCYTHE))
                return;
            IRule user = info.Used as IRule;
            Vector3Int i = new Vector3Int(
                Mathf.RoundToInt(user.Transform.position.x),
                Mathf.RoundToInt(user.Transform.position.y),
                Mathf.RoundToInt(user.Transform.position.z)
            );
            Vector3 cellWorld = _tilemap.CellToWorld(i);
            Vector3 worldCell = _tilemap.WorldToCell(cellWorld);
            Vector3Int delete = new Vector3Int(
                Mathf.RoundToInt(worldCell.x),
                Mathf.RoundToInt(worldCell.y),
                Mathf.RoundToInt(worldCell.z)
            );
            //Debug.LogFormat("{0} - {1} - {2} - {3}", i, cellWorld, worldCell, delete);
            _tilemap.SetTile(delete, null);
        }
    }
}