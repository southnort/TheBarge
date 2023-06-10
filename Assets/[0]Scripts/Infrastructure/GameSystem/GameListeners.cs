namespace Game.Infrastructure.GameSystem
{
    public interface IGameListener { }  //don't use this interface!!!

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
