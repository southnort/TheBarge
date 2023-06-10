using UnityEngine;
using UnityEngine.UI;


namespace Game.Infrastructure.LoadingSystem
{
    internal sealed class ApplicationLoader : MonoBehaviour
    {
        [SerializeField] private LoadingTask[] loadingTasks;

        private delegate void LoadingTaskDelegate(LoadingTask task);

        private async void Start()
        {
            foreach (var task in loadingTasks)
            {
                var result = await task.Do();

                if (!result.Success)
                {
                    Debug.LogError(result.Error);
                    continue;
                }
            }
        }
    }
}
