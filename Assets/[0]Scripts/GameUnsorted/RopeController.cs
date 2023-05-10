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
            var sprJoint = oneBody.gameObject.AddComponent<SpringJoint>();
            sprJoint.connectedBody = twoBody;

            oneRb = oneBody;
            twoRb = twoBody;     
        
        }

        private void Update()
        {
            if (oneRb == null || twoRb == null)
            {
                RemoveConnections();
            }

        }

        internal void RemoveConnections()
        {
            jointSettings.connectedBody = null;

            Destroy(gameObject);
        }




    }
}
