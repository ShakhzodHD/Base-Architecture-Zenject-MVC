using Core;
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

        [Inject]
        public void Initialize(SignalBus signalBus)
        {
            _signalBus = signalBus;
            SetupButtons();
        }

        private void SetupButtons()
        {
            playButton?.onClick.AddListener(() =>
                _signalBus.Fire(new GameStateChangeSignal(GameState.LevelSelect)));

            settingsButton?.onClick.AddListener(ShowSettings);

            exitButton?.onClick.AddListener(ExitGame);
        }

        protected override void OnShow()
        {
            Debug.Log("Main Menu View Shown");
        }

        protected override void OnHide()
        {
            Debug.Log("Main Menu View Hidden");
        }

        public void SetPlayerName(string name)
        {
            throw new System.NotImplementedException();
        }

        public void ShowLoadingState(bool isLoading)
        {
            throw new System.NotImplementedException();
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