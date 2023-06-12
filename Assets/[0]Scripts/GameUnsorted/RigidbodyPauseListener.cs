using Game.Infrastructure.GameSystem;
using UnityEngine;


namespace Game
{
    internal sealed class RigidbodyPauseListener : MonoBehaviour, IGamePauseListener
    {
        [SerializeField] private Rigidbody rb;
        private Vector3 _velocityOnPause;


        public void OnGamePause()
        {
            _velocityOnPause = rb.velocity;
            rb.velocity = Vector3.zero;
        }

        public void OnGameResume()
        {
            rb.velocity = _velocityOnPause;
        }
    }
}
