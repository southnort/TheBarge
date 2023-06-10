using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;


namespace Game.Infrastructure.LoadingSystem
{
    internal abstract class LoadingTask : MonoBehaviour
    {
        internal abstract UniTask<Result> Do();

        public struct Result
        {
            public bool Success;
            public string Error;
        }
    }
}
