using UnityEngine;
using UnityEngine.Tilemaps;
using Assets.Rules.Items;

namespace Assets.Rules.Grids
{
    public class PlantationGrid : 
        IRule,
        IUsableListener
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
            
        }

        public void Start()
        {
            
        }

        public void Update()
        {
            
        }

        public void ListenUsableWhileBeingUsed(UsableInfo info)
        {
            ItemTypes type = info.Used.Type;
            if (!type.Equals(Items.ItemTypes.SCYTHE))
                return;
            IRule used = info.Used as IRule;
            Vector3 worldCell = _tilemap.WorldToCell(used.Transform.position);
            Vector3Int delete = new Vector3Int(
                Mathf.RoundToInt(worldCell.x),
                Mathf.RoundToInt(worldCell.y),
                Mathf.RoundToInt(worldCell.z)
            );
            _tilemap.SetTile(delete, null);
        }

        public void ListenUsableAfterUse(UsableInfo info)
        {

        }
    }
}