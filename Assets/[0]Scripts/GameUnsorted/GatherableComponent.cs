using UnityEngine;
using UnityEngine.UI;
using TMPro;


namespace Default
{
    internal sealed class GatherableComponent : MonoBehaviour
    {
        [field: SerializeField] internal GatherableComponentType GatherType;
        [HideInInspector] internal bool IsGathering { get; set; }

    }


    [System.Serializable]
    internal enum GatherableComponentType
    {
        Asteroid,

    }
}
