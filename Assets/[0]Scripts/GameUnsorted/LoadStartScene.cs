using UnityEngine;
using UnityEngine.SceneManagement;


namespace Game.Infrastructure
{
    internal sealed class LoadStartScene : MonoBehaviour
    {
        private void Start()
        {
            SceneManager.LoadScene("StartScene");
        }
    }
}
