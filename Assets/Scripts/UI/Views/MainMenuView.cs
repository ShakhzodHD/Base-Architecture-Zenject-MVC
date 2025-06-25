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

            //settingsButton?.onClick.AddListener(() =>
            //    _signalBus.Fire(new GameEventSignal(GameEvent.OpenSettings)));

            exitButton?.onClick.AddListener(() =>
                _signalBus.Fire(new GameEventSignal(GameEvent.ExitGame)));
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
    }
}