using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Core
{
    public class GameController : IGameController, ITickable
    {
        private readonly Dictionary<GameState, IGameStateHandler> _stateHandlers;
        private readonly SignalBus _signalBus;

        private GameState _currentState;
        private GameState _previousState;

        public GameState CurrentState => _currentState;

        public GameController(
        Dictionary<GameState, IGameStateHandler> stateHandlers,
        SignalBus signalBus)
        {
            _stateHandlers = stateHandlers;
            _signalBus = signalBus;
        }

        public void Initialize()
        {
            _signalBus.Subscribe<GameEventSignal>(OnGameEvent);
            _signalBus.Subscribe<GameStateChangeSignal>(OnStateChangeRequest);

            ChangeState(GameState.MainMenu);
        }

        public void ChangeState(GameState newState)
        {
            if (_currentState == newState) return;

            if (_stateHandlers.ContainsKey(_currentState))
            {
                _stateHandlers[_currentState].Exit();
            }

            _previousState = _currentState;
            _currentState = newState;

            if (_stateHandlers.ContainsKey(_currentState))
            {
                _stateHandlers[_currentState].Enter();
            }

            _signalBus.Fire(new GameStateChangedSignal(_previousState, _currentState));
        }

        public void HandleGameEvent(GameEvent gameEvent)
        {
            switch (gameEvent)
            {
                case GameEvent.GameStarted:
                    HandleGameStarted();
                    break;
                case GameEvent.TutorialCompleted:
                    HandleTutorialCompleted();
                    break;
                case GameEvent.LevelCompleted:
                    HandleLevelCompleted();
                    break;
                case GameEvent.LevelFailed:
                    HandleLevelFailed();
                    break;
                case GameEvent.ReturnToMenu:
                    ChangeState(GameState.MainMenu);
                    break;
            }
        }

        public void Tick()
        {
            if (_stateHandlers.ContainsKey(_currentState))
            {
                _stateHandlers[_currentState].Update();
            }
        }

        private void OnGameEvent(GameEventSignal signal)
        {
            HandleGameEvent(signal.GameEvent);
        }

        private void OnStateChangeRequest(GameStateChangeSignal signal)
        {
            ChangeState(signal.NewState);
        }

        private void HandleGameStarted()
        {
            ChangeState(GameState.MainMenu);
        }

        private void HandleTutorialCompleted()
        {
            ChangeState(GameState.MainMenu);
        }

        private void HandleLevelCompleted()
        {
            ChangeState(GameState.MainMenu);
        }

        private void HandleLevelFailed()
        {
            ChangeState(GameState.GameOver);
        }
    }
}