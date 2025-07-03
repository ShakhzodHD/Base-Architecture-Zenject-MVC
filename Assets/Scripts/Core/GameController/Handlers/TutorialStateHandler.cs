using ScenesService;
using System;
using UnityEngine;
using Zenject;

namespace Core
{
    public class TutorialStateHandler : IGameStateHandler
    {
        private readonly SignalBus _signalBus;
        [Inject] private readonly IScenesService _scenesService;
        [Inject] private readonly IUIManager _uiManager;

        public TutorialStateHandler(SignalBus signalBus)
        {
            _signalBus = signalBus;
        }

        public void Enter()
        {
            Debug.Log("Tutorial Started");
        }

        public void Exit()
        {
            _uiManager.HideView<ILoadingScreenView>();

            Debug.Log("Tutorial Completed");
        }

        public void Update()
        {
            //_signalBus.Fire(new GameEventSignal(GameEvent.TutorialCompleted));

            if (Input.GetKey(KeyCode.Alpha1))
            {
                CompleteTutorial();
            }
        }

        public async void CompleteTutorial()
        {
            try
            {
                _uiManager.ShowView<ILoadingScreenView>();
                _signalBus.Fire(new GameEventSignal(GameEvent.ReturnToMenu));
                await _scenesService.LoadSceneAsync(Constants.MENU_SCENE_NAME);
                _uiManager.HideView<ILoadingScreenView>();
            }

            catch (Exception ex)
            {
                Debug.LogError($"Failed to load scene: {ex.Message}");
                _uiManager.HideView<ILoadingScreenView>();
            }
        }
    }
}