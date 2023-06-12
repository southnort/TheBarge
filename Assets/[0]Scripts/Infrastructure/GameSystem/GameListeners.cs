using System;


namespace Game.Infrastructure.GameSystem
{
    public interface IGameListener { }  //This is marker interface. Use concrete listener!!!

    public interface IGameStartListener : IGameListener
    {
        void OnGameStart();
    }

    public interface IGameFinishListener : IGameListener
    {
        void OnGameFinish();
    }

    public interface IGamePauseListener : IGameListener
    {
        void OnGamePause();
        void OnGameResume();
    }
}
