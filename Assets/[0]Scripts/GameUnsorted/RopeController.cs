using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Reflection;

namespace Default
{
    internal sealed class RopeController : MonoBehaviour
    {
        [SerializeField] private Rope visualRope;

        private Rigidbody _oneRb;
        private Rigidbody _twoRb;
        private Joint _joint;


        internal void ConnectBobyes(Rigidbody oneBody, Rigidbody twoBody)
        {
            _joint = AddJointToRigidbody(oneBody, twoBody);           

            _oneRb = oneBody;
            _twoRb = twoBody;

            visualRope.PointA = _oneRb.transform;
            visualRope.PointB = _twoRb.transform;
        }

        private Joint AddJointToRigidbody(Rigidbody body, Rigidbody connectedBody)
        {
            var joint = body.gameObject.AddComponent<ConfigurableJoint>();
            joint.connectedBody = connectedBody;

            joint.anchor = new Vector3(0, 0, -1f);
            joint.connectedAnchor = new Vector3(0, 0, -1f);
            
            joint.autoConfigureConnectedAnchor = false;

            joint.xMotion = ConfigurableJointMotion.Limited;
            joint.yMotion = ConfigurableJointMotion.Limited;
            joint.zMotion = ConfigurableJointMotion.Limited;

            var limit = joint.linearLimit;
            limit.limit = 20;
            joint.linearLimit = limit;

            joint.enableCollision = true;

            return joint;
        }

        private void Update()
        {
            if ((_oneRb == null || _twoRb == null) ||
                (_oneRb.isKinematic || _twoRb.isKinematic))
            {
                RemoveConnections();
            }

        }

        internal void RemoveConnections()
        {
            _joint.connectedBody = null;
            Destroy(_joint);
            Destroy(gameObject);
        }
    }
}
