using Cysharp.Threading.Tasks;
using System.Linq;
using UnityEngine;


namespace Game.Infrastructure.LoadingSystem
{
    internal sealed class LoadingTaskParallel : LoadingTask
    {
        [SerializeField] private LoadingTask[] loadingTasks;


        internal async override UniTask<Result> Do()
        {
            var length = loadingTasks.Length;
            UniTask<Result>[] tasks = new UniTask<Result>[length];

            for (int i = 0; i < length; i++)
            {
                UniTask<Result> task = loadingTasks[i].Do();
                tasks[i] = task;
            }

            Result[] results = await UniTask.WhenAll(tasks);

            return new Result
            {
                Success = results.All(x => x.Success)
            };
        }
    }
}
