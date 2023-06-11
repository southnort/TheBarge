using UnityEngine;


namespace Game
{
    internal sealed class AimController : MonoBehaviour
    {
        [SerializeField] private LayerMask raycastLayerMask;
        private Camera _camera;

        private void Start()
        {
            _camera = Camera.main;
        }

        private void Update()
        {
            var mouse = Input.mousePosition;
            Ray castPoint = _camera.ScreenPointToRay(mouse);
            if (Physics.Raycast(castPoint, out var hit, Mathf.Infinity, raycastLayerMask))
            {
                transform.position = hit.point;
            }
        }
    }
}
