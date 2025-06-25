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
            // Показываем UI выбора уровней
        }

        public void Exit()
        {
            // Скрываем UI выбора уровней
        }

        public void Update()
        {
            // Пример выбора уровня
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