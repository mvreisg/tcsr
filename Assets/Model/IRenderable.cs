using UnityEngine;

namespace Assets.Model
{
    public interface IRenderable
    {
        Renderer Renderer { get; }
    }
}