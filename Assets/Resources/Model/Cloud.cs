using UnityEngine;

namespace Assets.Resources.Model
{
    public class Cloud : Entity, IVisible
    {
        private SpriteRenderer _spriteRenderer;
        private Camera _camera;

        public SpriteRenderer SpriteRenderer => _spriteRenderer;

        public delegate void VisibleEventHandler();

        public event VisibleEventHandler OutOfSight;

        public Cloud(Transform transform, Multiplier x, Multiplier y, Multiplier z, XYZValue speed, Camera camera) : base(transform, x, y, z, speed)
        {
            _spriteRenderer = transform.GetComponent<SpriteRenderer>();
            _camera = camera;
        }

        public void Disappear()
        {
            bool visibleByCamera = GeometryUtility.TestPlanesAABB(GeometryUtility.CalculateFrustumPlanes(_camera), SpriteRenderer.bounds);
            if (!visibleByCamera)
                OnOutOfSight();
        }

        private void OnOutOfSight()
        {
            OutOfSight?.Invoke();
            Object.Destroy(Transform.gameObject);
            Object.Destroy(Transform.GetComponent<MonoBehaviour>());
        }
    }
}