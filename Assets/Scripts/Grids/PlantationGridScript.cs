using UnityEngine;
using Assets.Rules.Grids;
using Assets.Rules;

namespace Assets.Scripts.Grids
{
    public class PlantationGridScript : MonoBehaviour,
        IRuleScript
    {
        private IRule _plantationGrid;

        public IRule Rule => _plantationGrid;

        private void Awake()
        {
            _plantationGrid = new PlantationGrid(transform);
            _plantationGrid.Awake();
        }

        private void Start()
        {
            _plantationGrid.Start();
        }

        private void Update()
        {
            _plantationGrid.Update();
        }
    }
}