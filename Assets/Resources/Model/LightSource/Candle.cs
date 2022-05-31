using UnityEngine;

namespace Assets.Resources.Models.LightSources
{
    public abstract class Candle : LightSource
    {
        public Candle(Transform transform, Light light) : base(transform, light)
        {

        }
    }
}