using UnityEngine;
using Zenject;

namespace Core
{
    public class MainMenuStateHandler : IGameStateHandler
    {
        private readonly SignalBus _signalBus;

        public MainMenuStateHandler(SignalBus signalBus)
        {
            _signalBus = signalBus;
        }

        public void Enter()
        {
            Debug.Log("Main Menu Opened");
            // ���������� ������� ���� UI
        }

        public void Exit()
        {
            // �������� ������� ���� UI
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