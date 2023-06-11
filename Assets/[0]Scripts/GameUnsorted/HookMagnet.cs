using UnityEngine;


namespace Game
{
    internal sealed class HookMagnet : MonoBehaviour
    {
        [SerializeField] private TriggerComponent trigger;
        [SerializeField] private Rigidbody emptyJointTarget;
        [SerializeField] private Joint joint;


        private void Start()
        {
            trigger.OnTriggerEntered += ConnectBody;
        }

        internal void Disconnect()
        {
            joint.connectedBody = emptyJointTarget; 
        }

        private void ConnectBody(Collider collider)
        {
            joint.connectedBody = collider.attachedRigidbody;
        }
    }
}
