using System.Collections.Generic;

namespace Game.Infrastructure.GameSystem
{
    public sealed class GameManager
    {
        private readonly List<IGameListener> _listeners = new();
        public GameState GameState { get; private set; }

        public void AddListener(IGameListener listener)
        {
            if (listener == null) return;
            _listeners.Add(listener);
        }

        public void RemoveListener(IGameListener listener)
        {
            if (listener == null) return;
            _listeners.Remove(listener); 
        }



        public void StartGame()
        {
            foreach (var listener in _listeners)
            {
                if (listener == null) continue;
                if (listener is IGameStartListener startListener)
                {
                    startListener.OnGameStart();
                }
            }
            GameState = GameState.Play;
        }

        public void PauseGame()
        {
            foreach (var listener in _listeners)
            {
                if (listener == null) continue;
                if (listener is IGamePauseListener pauseListener)
                {
                    pauseListener.OnGamePause();
                }
            }
            GameState = GameState.Paused;
        }

        public void ResumeGame()
        {
            foreach (var listener in _listeners)
            {
                if (listener == null) continue;
                if (listener is IGamePauseListener pauseListener)
                {
                    pauseListener.OnGameResume();
                }
            }
            GameState = GameState.Play;
        }

        public void FinishGame()
        {
            foreach (var listener in _listeners)
            {
                if (listener == null) continue;
                if (listener is IGameFinishListener finishListener)
                {
                    finishListener.OnGameFinish();
                }
            }
            GameState = GameState.Finished;
        }
    }

    public enum GameState
    {
        Default,
        Play,
        Paused,
        Finished,
    }
}
