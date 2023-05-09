using UnityEngine;
using UnityEngine.UI;
using TMPro;


namespace Default
{
    internal sealed class RopeController : MonoBehaviour
    {
        [SerializeField] private Joint jointSettings;
        [SerializeField] private Rigidbody oneRb;
        [SerializeField] private Rigidbody twoRb;


        internal void ConnectBobyes(Rigidbody oneBody, Rigidbody twoBody)
        {
            jointSettings = oneBody.gameObject.AddComponent<SpringJoint>();
            jointSettings.connectedBody = twoBody;

            oneRb = oneBody;
            twoRb = twoBody;     
        
        }

        internal void RemoveConnections()
        {
            jointSettings.connectedBody = null;

        }




    }
}
