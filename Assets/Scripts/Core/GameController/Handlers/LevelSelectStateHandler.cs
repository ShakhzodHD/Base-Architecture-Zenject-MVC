using UnityEngine;
using Zenject;

namespace Core
{
    public class LevelSelectStateHandler : IGameStateHandler
    {
        private readonly SignalBus _signalBus;

        public LevelSelectStateHandler(SignalBus signalBus)
        {
            _signalBus = signalBus;
        }

        public void Enter()
        {
            Debug.Log("Level Select Opened");
            // ���������� UI ������ �������
        }

        public void Exit()
        {
            // �������� UI ������ �������
        }

        public void Update()
        {
            // ������ ������ ������
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                _signalBus.Fire(new GameStateChangeSignal(GameState.InGame));
            }

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                _signalBus.Fire(new GameStateChangeSignal(GameState.MainMenu));
            }
        }
    }
}