using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Game;

namespace Yarigg
{
    internal sealed class ShootingTestSystem : MonoBehaviour
    {
        [SerializeField] private HookModuleController moduleController;
        [SerializeField] private PlayerAimSystem playerAimSystem;

        private bool _isAiming;



        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                ClickOnModule();
            }
        }

        public void ClickOnModule()
        {
            _isAiming = !_isAiming;

            if (_isAiming)
            {
                CancelShooting();
            }

            else
            {
                StartShooting();
            }                
        }



        private void StartShooting()
        {
            playerAimSystem.StartAim(moduleController.Shot);
        }

        private void CancelShooting()
        {
            playerAimSystem.StopAim();
        }
    }
}
