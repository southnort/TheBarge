using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting.YamlDotNet.Core.Tokens;


namespace Default
{
    internal sealed class PlayerShipView : MonoBehaviour, IInputController
    {
        [SerializeField] private Transform moveRoot;
        [SerializeField] private ShipModel shipModel;
        private ShipModel _shipData => shipModel;


        [Space]
        [Header("Phycics")]
        [SerializeField] private Rigidbody physicBody;








        public void SetInputData(Vector2 horizontalVerticalInputData)
        {
            var hor = horizontalVerticalInputData.x;
            var vert = horizontalVerticalInputData.y;


            Rotate(hor);
            Move(vert);
        }


        public void SetAction(InputActions action)
        {
            if (action == InputActions.SpaceButton)
            {
                BrakeRotating();
                BrakeMoving();
            }
        }


        private void Move(float vert)
        {           
            if (vert > 0)
            {
                physicBody.AddForce(moveRoot.forward * vert * shipModel.accelerationModifier * Time.deltaTime);
            }
            else
            {
                physicBody.AddForce(moveRoot.forward * vert * shipModel.moveBrakeModifier * Time.deltaTime);
            }               
        }



        private void Rotate(float hor)
        {
            var absHor = Mathf.Abs(hor);
            var value = Mathf.Lerp(_shipData.minMaxRotation.x, _shipData.minMaxRotation.y, absHor) * _shipData.rotationForceModifier;
            if (hor < 0)
                value *= -1;

            physicBody.AddTorque(0f, value * Time.deltaTime, 0f);
        }

        private void BrakeRotating()
        {
            var value = physicBody.angularVelocity;

            physicBody.angularVelocity = Vector3.MoveTowards(value, Vector3.zero, _shipData.rotationBrakeModifier * Time.deltaTime);
        }

        private void BrakeMoving()
        {
            var value = physicBody.velocity;

            physicBody.velocity = Vector3.MoveTowards(value, Vector3.zero, _shipData.moveBrakeModifier * Time.deltaTime);
        }



    }
}
