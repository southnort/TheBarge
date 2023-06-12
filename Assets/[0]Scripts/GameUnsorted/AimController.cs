using UnityEngine;
using Game.Input;
using UnityEngine.Tilemaps;

namespace Game
{
    internal sealed class AimController : MonoBehaviour
    {
        [SerializeField] private LayerMask raycastLayerMask;
        [SerializeField] private InputController input;
        private Camera _camera;

        private void Start()
        {
            _camera = Camera.main;
        }

        private void OnEnable()
        {
            if (input.CurrentDevice == InputDeviceType.Gamepad)
            {
                transform.localPosition = Vector3.zero;
            }

            else
            {
                SynchronizeWithMousePosition();
            }
        }

        private void SynchronizeWithMousePosition()
        {
            var mouse = input.MousePosition;
            Ray castPoint = _camera.ScreenPointToRay(mouse);
            if (Physics.Raycast(castPoint, out var hit, Mathf.Infinity, raycastLayerMask))
            {
                transform.position = hit.point;
            }
        }

        private void Update()
        {
            if (input.CurrentDevice == InputDeviceType.Gamepad)
            {
                Vector3 deltaMove = input.SecondaryInputAxes * Time.deltaTime * 20f;
                transform.localPosition += new Vector3(deltaMove.x, 0, deltaMove.y);
            }

            else
            {
                SynchronizeWithMousePosition();
            }
        }
    }
}
