using UnityEngine;
using Zenject;

namespace Core
{
    public class GameOverStateHandler : IGameStateHandler
    {
        private readonly SignalBus _signalBus;

        public GameOverStateHandler(SignalBus signalBus)
        {
            _signalBus = signalBus;
        }

        public void Enter()
        {
            Debug.Log("Game Over");
            // Показываем UI Game Over
        }

        public void Exit()
        {
            // Скрываем UI Game Over
        }

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.R))
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