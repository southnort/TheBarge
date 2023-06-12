using System;


namespace Game.Infrastructure
{
    public static class ErrorsLogger
    {
        public static event Action<string> OnErrorLogged;


        public static void LogError(string message)
        {
            OnErrorLogged?.Invoke(message);
        }
    }
}
