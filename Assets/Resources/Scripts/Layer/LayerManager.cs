using System.Collections.Generic;
using UnityEngine;

namespace Assets.Resources.Scripts.Layer
{
    public class LayerManager : MonoBehaviour
    {
        public const string GROUND = "Ground";
        public const string DIAGONAL = "Diagonal";
        public const string WALL = "Wall";

        private Dictionary<string, int> _layers;

        public int Ground
        {
            get
            {
                return _layers[GROUND];
            }
        }

        public int Diagonal
        {
            get
            {
                return _layers[DIAGONAL];
            }
        }

        public int Wall
        {
            get
            {
                return _layers[WALL];
            }
        }

        private void Awake()
        {
            _layers = new Dictionary<string, int>();
            _layers.Add(GROUND, LayerMask.NameToLayer(GROUND));
            _layers.Add(DIAGONAL, LayerMask.NameToLayer(DIAGONAL));
            _layers.Add(WALL, LayerMask.NameToLayer(WALL));
        }
    }
}