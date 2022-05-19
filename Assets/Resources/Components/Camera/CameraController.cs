using UnityEngine;
using Assets.Resources.Pure;
using Assets.Resources.Components.Character;

namespace Assets.Resources.Components.Camera
{
    public class CameraController : MonoBehaviour
    {
        private void Start()
        {
            GameObject.FindGameObjectWithTag(Tag.BLU).GetComponent<Blu>().Moved += CharacterMoved;
        }

        private void CharacterMoved(Vector3 position)
        {
            transform.position = new Vector3(position.x, position.y + 1f, position.z);
        }
    }
}