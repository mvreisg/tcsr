using UnityEngine;

namespace Assets.Resources.Scripts
{
    public interface IDestroyable
    {
        delegate void DestroyDelegate(GameObject gameObject);
        event DestroyDelegate DestroyEvent;
    }
}