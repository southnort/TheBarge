using UnityEngine;

namespace Default
{
    internal interface IInputController
    {
        public void SetInputData(Vector2 horizontalVerticalInputData);
        public void SetAction(InputActions action);
    }
}
