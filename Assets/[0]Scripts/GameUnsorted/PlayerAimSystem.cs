using UnityEngine;
using System;


namespace Game
{
    internal sealed class PlayerAimSystem : MonoBehaviour
    {
        [SerializeField] private GameObject aimObject;

        internal event Action<Vector3> OnConfirmShot;


        internal void StartAim(Action<Vector3> onConfirmShot)
        {
            aimObject.SetActive(true);
            OnConfirmShot = onConfirmShot;
        }

        internal void StopAim()
        {
            aimObject.SetActive(false);
            OnConfirmShot = null;
        }

        public void ConfirmShot()
        {
            OnConfirmShot?.Invoke(aimObject.transform.position);
            StopAim();
        }
    }
}
