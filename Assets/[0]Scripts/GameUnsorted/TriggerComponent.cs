using UnityEngine;
using System;
using System.Linq;

namespace Game
{
    internal sealed class TriggerComponent : MonoBehaviour
    {
        [SerializeField] private string[] handlingTags;

        internal Action<Collider> OnTriggerEntered;
        internal Action<Collider> OnTriggerExited;

        private void OnTriggerEnter(Collider other)
        {
            if (handlingTags.Contains(other.tag))
            {
                OnTriggerEntered?.Invoke(other);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (handlingTags.Contains(other.tag))
            {
                OnTriggerExited?.Invoke(other);
            }
        }
    }
}
