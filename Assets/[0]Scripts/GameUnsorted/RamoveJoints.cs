using UnityEngine;
using UnityEngine.UI;
using TMPro;


namespace Default
{
    internal sealed class RamoveJoints : MonoBehaviour
    {
        internal void RemovePhysics()
        {
            var list = transform.GetComponentsInChildren<Rigidbody>();

            foreach (var rb in list)
            {
                rb.isKinematic = true;
            }
        }

    }
}
