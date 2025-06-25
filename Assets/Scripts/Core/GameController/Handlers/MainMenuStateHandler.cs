using UnityEngine;
using Zenject;

namespace Core
{
    public class MainMenuStateHandler : IGameStateHandler
    {
        private readonly SignalBus _signalBus;
        private readonly IUIManager _uiManager;

        public MainMenuStateHandler(SignalBus signalBus, IUIManager uiManager)
        {
            _signalBus = signalBus;
            _uiManager = uiManager;
        }

        public void Enter()
        {
            Debug.Log("Main Menu Opened");
            _uiManager.ShowView<IMainMenuView>();
            // Показываем главное меню UI
        }

        public void Exit()
        {
            _uiManager.HideView<IMainMenuView>();
            // Скрываем главное меню UI
        }

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                _signalBus.Fire(new GameStateChangeSignal(GameState.LevelSelect));
            }
        }
    }
}