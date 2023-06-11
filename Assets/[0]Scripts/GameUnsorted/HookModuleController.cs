using System;
using UnityEngine;


namespace Game
{
    internal sealed class HookModuleController : MonoBehaviour
    {
        [SerializeField] private HookMagnet magnet;
        [SerializeField] private ConfigurableJoint joint;
        [SerializeField] private float maxJointDistance = 20;
        [SerializeField] private Rigidbody hookBody;


        private void Start()
        {
            SetJointLimit(0);
        }

        private void SetJointLimit(float value)
        {
            var limit = joint.linearLimit;
            limit.limit = value;
            joint.linearLimit = limit;
        }

        private void SetDisconnected()
        {
            magnet.Disconnect();
        }

        internal void Shot(Vector3 aimPosition)
        {
            SetJointLimit(maxJointDistance);
            var delta = aimPosition - transform.position;
            hookBody.velocity = delta * 1f;
        }
    }
}
