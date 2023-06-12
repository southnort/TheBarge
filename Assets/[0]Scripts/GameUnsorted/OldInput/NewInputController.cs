using Default;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;


namespace Default
{
    internal sealed class NewInputController : MonoBehaviour
    {
        [SerializeField] private UnityEvent onEmptyPlaceLeftClicked;
        [SerializeField] private UnityEvent onEmptyPlaceRightClicked;

        [Space]
        [SerializeField] PlayerShipView _playerShipView;
      //  private IInputController _inputController => _playerShipView;

        private Vector2 _inputData;

        private bool _isBraking;

        private float _leftTriggerValue;
        private float _rightTriggerValue;


        private Camera _cam;
        private Camera getCamera
        {
            get
            {
                if (_cam == null)
                {
                    _cam = Camera.main;
                }

                return _cam;
            }
        }



        private void Start()
        {
            var plInput = Object.FindObjectOfType<PlayerInput>();

            var controls = plInput.actions;
            var actionMap = controls.FindActionMap("Player");



            var moving = actionMap.FindAction("Move");
            moving.started += MoveAction;
            moving.performed += MoveAction;
            moving.canceled += MoveAction;

            var shooting = actionMap.FindAction("Fire");
            shooting.started += FireAction;
            shooting.performed += FireAction;
            shooting.canceled += FireAction;

            var altShooting = actionMap.FindAction("AlternativeFire");
            altShooting.started += AlternativeFireAction;
            altShooting.performed += AlternativeFireAction;
            altShooting.canceled += AlternativeFireAction;

            var rTrigger = actionMap.FindAction("RightTrigger");
            rTrigger.started += RTriggerHanle;
            rTrigger.performed += RTriggerHanle;
            rTrigger.canceled += RTriggerHanle;

            var lTrigger = actionMap.FindAction("LeftTrigger");
            lTrigger.started += LTriggerHanle;
            lTrigger.performed += LTriggerHanle;
            lTrigger.canceled += LTriggerHanle;
        }


        private void RTriggerHanle(InputAction.CallbackContext obj)
        {
            _inputData.y = obj.ReadValue<float>();
        }

        private void LTriggerHanle(InputAction.CallbackContext obj)
        {
            _inputData.y = -obj.ReadValue<float>();
        }



        private void Update()
        {
          //  _inputController.SetInputData(_inputData);

            if (_isBraking)
            {
           //     _inputController.SetAction(InputActions.SpaceButton);
            }

            HandleMouseClicks();

        }

        private void HandleMouseClicks()
        {
            bool isLeftClicked = Input.GetMouseButtonDown(0);
            bool isRightClicked = Input.GetMouseButtonDown(1);



            if (isLeftClicked || isRightClicked)
            {
                Ray inputRay = getCamera.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(inputRay, out var hit))
                {
                    if (hit.collider.gameObject.TryGetComponent<MouseClickableComponent>(out var clicked))
                    {
                        if (isLeftClicked)
                            clicked.LeftMouseClick();

                        if (isRightClicked)
                            clicked.RightMouseClick();
                    }

                    else
                    {
                        if (isLeftClicked)
                            onEmptyPlaceLeftClicked?.Invoke();

                        if (isRightClicked)
                            onEmptyPlaceRightClicked?.Invoke();
                    }
                }
            }
        }


        private void MoveAction(InputAction.CallbackContext obj)
        {
            _inputData = obj.ReadValue<Vector2>();
        }

        private void FireAction(InputAction.CallbackContext obj)
        {
            _isBraking = obj.ReadValueAsButton();
        }

        private void AlternativeFireAction(InputAction.CallbackContext obj)
        {
            _isBraking = obj.ReadValueAsButton();
        }
    }
}