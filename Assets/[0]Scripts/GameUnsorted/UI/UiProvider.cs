using Game.Infrastructure.GameSystem;
using UnityEngine;
using VContainer;
using Yrr.UI;


namespace Game.UI
{
    public sealed class UiProvider : MonoBehaviour
    {
        [SerializeField] private UIManager uiManager;
        private GameManager _gameManager;


        [Inject]
        public void Construct(GameManager gameManager)
        {
            _gameManager = gameManager;

            uiManager.OnScreenShown += OnShowScreen;
            uiManager.OnScreenHided += OnHideScreen;
        }

        private void OnShowScreen(UIScreen screen)
        {
            if (screen is BargeScreen bargeScreen)
            {
                if (bargeScreen.NeedStopTimeOnShow)
                    _gameManager.PauseGame();
            }
        }

        private void OnHideScreen(UIScreen screen)
        {
            if (screen is BargeScreen bargeScreen)
            {
                if (bargeScreen.NeedStopTimeOnShow)
                    _gameManager.ResumeGame();
            }
        }
    }
}
