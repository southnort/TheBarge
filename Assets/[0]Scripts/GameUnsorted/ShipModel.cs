using UnityEngine;
using UnityEngine.UI;
using TMPro;


namespace Default
{
    [CreateAssetMenu(fileName = "DataSO", menuName = "Data/Ship_Model", order = 51)]
    internal sealed class ShipModel : ScriptableObject
    {
        [field: SerializeField] public Vector2 minMaxRotation { get; private set; }       
        [field: SerializeField] public float rotationForceModifier { get; private set; }
        [field: SerializeField] public float rotationBrakeModifier { get; private set; }
        [field: SerializeField] public float accelerationModifier{get; private set; }

       [field: SerializeField] public float moveBrakeModifier{get; private set; }

    }
}
