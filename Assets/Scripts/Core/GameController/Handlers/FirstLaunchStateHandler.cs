using ScenesService;
using UnityEngine;
using Zenject;

namespace Core
{
    public class FirstLaunchStateHandler : IGameStateHandler
    {
        private readonly SignalBus _signalBus;
        private readonly IUIManager _uiManager;
        [Inject] private readonly IScenesService _scenesService;

        public FirstLaunchStateHandler(SignalBus signalBus, IUIManager uiManager)
        {
            _signalBus = signalBus;
            _uiManager = uiManager;
        }

        public void Enter()
        {
            _uiManager.ShowView<ILoadingScreenView>();

            _signalBus.Fire(new GameStateChangeSignal(GameState.Tutorial));

            _scenesService.LoadSceneAsync(Constants.TUTORIAL_SCENE_NAME);
        }

        public void Exit()
        {
            Debug.Log("First Launch Hidden");

            _uiManager.HideView<ILoadingScreenView>();
        }

        public void Update()
        {
        }
    }
}