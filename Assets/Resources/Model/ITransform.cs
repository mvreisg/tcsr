using UnityEngine;

namespace Assets.Resources.Model
{
    public interface ITransform
    {
        XYZValue Speed { get; }
        Multiplier X { get; }
        Multiplier Y { get; }
        Multiplier Z { get; }
        void Move();
    }
}