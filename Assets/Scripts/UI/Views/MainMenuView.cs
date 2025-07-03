using Core;
using ScenesService;
using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UIManager
{
    public class MainMenuView : UIView, IMainMenuView
    {
        [SerializeField] private Button playButton;
        [SerializeField] private Button settingsButton;
        [SerializeField] private Button exitButton;

        [SerializeField] private GameObject settingPanel;

        private SignalBus _signalBus;

        [Inject] private readonly IUIManager _uiManager;
        [Inject] private readonly IScenesService _scenesService;

        [Inject]
        public void Initialize(SignalBus signalBus)
        {
            _signalBus = signalBus;
            SetupButtons();
        }

        private void SetupButtons()
        {
            playButton?.onClick.AddListener(PlayGame);

            settingsButton?.onClick.AddListener(ShowSettings);

            exitButton?.onClick.AddListener(ExitGame);
        }

        protected override void OnShow()
        {
        }

        protected override void OnHide()
        {
        }

        public void SetPlayerName(string name)
        {
            throw new NotImplementedException();
        }

        public void ShowLoadingState(bool isLoading)
        {
            throw new NotImplementedException();
        }

        private async void PlayGame()
        {
            try
            {
                _uiManager.ShowView<ILoadingScreenView>();
                _signalBus.Fire(new GameStateChangeSignal(GameState.Tutorial));
                await _scenesService.LoadSceneAsync(Constants.TUTORIAL_SCENE_NAME);
                _uiManager.HideView<ILoadingScreenView>();
            }
            catch (Exception ex)
            {
                Debug.LogError($"Failed to load scene: {ex.Message}");
                _uiManager.HideView<ILoadingScreenView>();
            }
        }

        private void ShowSettings()
        {
            settingPanel.SetActive(true);
        }

        private void ExitGame()
        {
            Application.Quit();
        }

        private void OnDestroy()
        {
            playButton?.onClick.RemoveAllListeners();
            settingsButton?.onClick.RemoveAllListeners();
            exitButton?.onClick.RemoveAllListeners();
        }
    }
}