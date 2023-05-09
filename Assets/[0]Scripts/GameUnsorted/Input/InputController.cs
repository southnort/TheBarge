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
        }
    }


    internal enum InputActions
    {
        SpaceButton,
        CtrlButton,
    }
}
