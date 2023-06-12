using System;
using UnityEngine;
using UnityEngine.InputSystem;


namespace Game.Input
{
    public sealed class InputController : MonoBehaviour
    {
        [SerializeField] private PlayerInput playerInput;

        public InputDeviceType CurrentDevice { get; private set; }
        public event Action<InputDeviceType> OnDeviceChanged;


        public Vector2 MainInputAxes => _inputData;
        private Vector2 _inputData;

        public Vector2 SecondaryInputAxes => _secondaryInputData;
        private Vector2 _secondaryInputData;
        public Vector3 MousePosition => UnityEngine.Input.mousePosition;


        private void Start()
        {
            var controls = playerInput.actions;
            var actionMap = controls.FindActionMap("Player");

            var moving = actionMap.FindAction("Move");
            moving.started += MoveAction;
            moving.performed += MoveAction;
            moving.canceled += MoveCancel;

            var gamepadMoving = actionMap.FindAction("GamepadMove");
            gamepadMoving.started += GamepadMovingAction;
            gamepadMoving.performed += GamepadMovingAction;
            gamepadMoving.canceled += GamepadMovingCancel;

            var look = actionMap.FindAction("Look");
            look.started += LookAction;
            look.performed += LookAction;
            look.canceled += LookActionCancel;

            var gamepadLook = actionMap.FindAction("GamepadLook");
            gamepadLook.started += GamepadLookAction;
            gamepadLook.performed += GamepadLookAction;
            gamepadLook.canceled += GamepadLookCancel;

            var rightMouse = actionMap.FindAction("RightMouseClick");
            rightMouse.canceled += LookActionCancel;

            var rTrigger = actionMap.FindAction("RightTrigger");
            rTrigger.started += RTriggerHanle;
            rTrigger.performed += RTriggerHanle;
            rTrigger.canceled += RTriggerCancel;

            var lTrigger = actionMap.FindAction("LeftTrigger");
            lTrigger.started += LTriggerHanle;
            lTrigger.performed += LTriggerHanle;
            lTrigger.canceled += LTriggerCancel;
        }

        private void SetDevice(InputDeviceType device)
        {
            if (CurrentDevice == device) return;

            CurrentDevice = device;
            OnDeviceChanged?.Invoke(CurrentDevice);
        }



        private void MoveAction(InputAction.CallbackContext context)
        {
            _inputData = context.ReadValue<Vector2>();
            SetDevice(InputDeviceType.KeyboardMouse);
        }

        private void MoveCancel(InputAction.CallbackContext context)
        {
            _inputData = Vector3.zero;
        }


        private void GamepadMovingAction(InputAction.CallbackContext context)
        {
            _inputData = context.ReadValue<Vector2>();
            SetDevice(InputDeviceType.Gamepad);
        }

        private void GamepadMovingCancel(InputAction.CallbackContext context)
        {
            _inputData = Vector3.zero;
        }


        private void LookAction(InputAction.CallbackContext context)
        {
            if (UnityEngine.Input.GetMouseButtonDown(1))
            {
                _secondaryInputData = context.ReadValue<Vector2>();
                SetDevice(InputDeviceType.KeyboardMouse);
            }
        }

        private void LookActionCancel(InputAction.CallbackContext context)
        {
            _secondaryInputData = Vector3.zero;
        }

        private void GamepadLookAction(InputAction.CallbackContext context)
        {
            _secondaryInputData = context.ReadValue<Vector2>();
            SetDevice(InputDeviceType.Gamepad);
        }

        private void GamepadLookCancel(InputAction.CallbackContext context)
        {
            _secondaryInputData = Vector3.zero;
        }




        private void RTriggerHanle(InputAction.CallbackContext context)
        {
            _inputData.y = context.ReadValue<float>();
            SetDevice(InputDeviceType.Gamepad);
        }

        private void RTriggerCancel(InputAction.CallbackContext context)
        {
            _inputData.y = 0;
        }

        private void LTriggerHanle(InputAction.CallbackContext context)
        {
            _inputData.y = -context.ReadValue<float>();
            SetDevice(InputDeviceType.Gamepad);
        }

        private void LTriggerCancel(InputAction.CallbackContext context)
        {
            _inputData.y = 0;
        }

    }

    public enum InputDeviceType
    {
        None,
        KeyboardMouse,
        Gamepad,
    }
}
