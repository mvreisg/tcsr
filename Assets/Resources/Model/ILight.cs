using UnityEngine;

namespace Assets.Resources.Model
{
    public interface ILight
    {
        public Light Light { get; }
        public float Intensity { get; set; }
    }
}