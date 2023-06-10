using Cysharp.Threading.Tasks;
using Yarigg;


namespace Game.Infrastructure.LoadingSystem
{
    internal sealed class LoadingTask_StartPlugins : LoadingTask
    {
        internal override UniTask<Result> Do()
        {
            var result = new UniTaskCompletionSource<Result>();
            AppsFlyerManager.StartSDK(
                onSuccess: () => result.TrySetResult(new Result
                {
                    Success = true,
                }),
                onError: err => result.TrySetResult(new Result
                {
                    Success = false,
                    Error = err,
                })
            );

            return result.Task;
        }
    }
}
