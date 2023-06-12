using UnityEngine;
using UnityEngine.UI;
using TMPro;


namespace Default
{
    internal sealed class JointConnector : MonoBehaviour
    {
        internal static JointConnector Instance;
        [SerializeField] private RopeController ropePrefab;

        private Rigidbody _rb1;
        private Rigidbody _rb2;

        private void Awake()
        {
            Instance = this;
        }


        public void AddConnectedBody(Rigidbody rb)
        {
            if (_rb1 == null)
            {
                _rb1 = rb;
            }
            else if (_rb1 == rb) return;

            else
            {
                _rb2 = rb;
                var connector = Instantiate(ropePrefab);
                connector.ConnectBobyes(_rb1, _rb2);

                Drop();
            }
        }

        public void Drop()
        {
            _rb1 = null;
            _rb2 = null;
        }




    }
}
