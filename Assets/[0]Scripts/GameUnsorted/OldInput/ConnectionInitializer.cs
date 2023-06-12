using UnityEngine;
using UnityEngine.UI;
using TMPro;


namespace Default
{
    internal sealed class ConnectionInitializer : MonoBehaviour
    {
        [SerializeField] private Rigidbody rb;

        public void Connect()
        {
            JointConnector.Instance.AddConnectedBody(rb);
        }

    }
}
