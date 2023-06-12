using System;
using UnityEngine;


namespace Yarigg
{
    internal sealed class AppsFlyerManager
    {
        private const bool _success = true;

        public static void StartSDK(Action onSuccess, Action<string> onError)
        {
            if (_success)
            {
                Debug.Log("AppsFlyer Started");
                onSuccess?.Invoke();
            }
            //else
            //{
            //    onError?.Invoke("AppsFlyer init failed!");
            //}
        }
    }
}
