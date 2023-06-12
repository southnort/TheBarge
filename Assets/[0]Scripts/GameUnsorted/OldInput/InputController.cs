using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Yrr.Utils;

namespace Default
{
    internal sealed class InputController : MonoBehaviour
    {
        private const string horizontalConstant = "Horizontal";
        private const string verticalConstant = "Vertical";

        private const string joyVerticalUp = "9th Axis";
        private const string joyVerticalDown = "10th Axis";

        [SerializeField] PlayerShipView _playerShipView;
        private IInputController _inputController => _playerShipView;


#if UNITY_EDITOR
        [ReadOnly]
        public Vector2 PositionData;
#endif
        private Vector2 _inputData;



        private void Update()
        {
            var horizontal = Input.GetAxis(horizontalConstant);
            var vertical = Input.GetAxis(verticalConstant);

            _inputData.x = horizontal;
            _inputData.y = vertical;

            _inputController.SetInputData(_inputData);

#if UNITY_EDITOR
            PositionData = _inputData;
#endif


            if (Input.GetKey(KeyCode.Space))
            {
                _inputController.SetAction(InputActions.SpaceButton);
            }

            var joyVert = Input.GetAxis(joyVerticalUp) - Input.GetAxis(joyVerticalDown);
            if (joyVert != 0)
            {
                _inputData.y = joyVert;
            }
        }
    }


    internal enum InputActions
    {
        SpaceButton,
        CtrlButton,
    }
}
