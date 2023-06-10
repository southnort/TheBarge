using System.Collections;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;


namespace Game.Infrastructure.LoadingSystem
{
    internal sealed class LoadingTask_LoadGameScene : LoadingTask
    {
        internal async override UniTask<Result> Do()
        {
            await LoadGameScene();
            return await Task.FromResult(new Result
            {
                Success = true
            });
        }

        private IEnumerator LoadGameScene()
        {
            var sceneName = "SampleScene";
            SceneManager.LoadScene(sceneName);
            
            var operation = SceneManager.LoadSceneAsync(sceneName);
            while (!operation.isDone)
            {
                // LoadingScreen.ReportProgress(operation.progress / 2);
                yield return null;
            }
        }
    }
}
