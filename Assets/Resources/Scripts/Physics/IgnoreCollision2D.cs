using System.Collections.Generic;
using UnityEngine;
namespace Assets.Resources.Scripts.Physics
{
    public class IgnoreCollision2D : MonoBehaviour
    {
        [SerializeField]
        private List<Collider2D> _collidersToBeIgnored;

        private void Awake()
        {
            Collider2D collider = GetComponent<Collider2D>();
            _collidersToBeIgnored.ForEach((other) => {
                Physics2D.IgnoreCollision(collider, other);
            });
        }
    }
}