using UnityEngine;

namespace Assets.Rules
{
    public interface IRenderable
    {
        Renderer Renderer { get; }
    }
}