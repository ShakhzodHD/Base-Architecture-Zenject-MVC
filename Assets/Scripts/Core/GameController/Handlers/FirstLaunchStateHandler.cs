using DG.Tweening;
using UnityEngine;
using Zenject;

namespace Core
{
    public class FirstLaunchStateHandler : IGameStateHandler
    {
        private readonly SignalBus _signalBus;

        public FirstLaunchStateHandler(SignalBus signalBus)
        {
            _signalBus = signalBus;
        }

        public void Enter()
        {
            Debug.Log("First Launch - показываем заставку/логотип");
            DOVirtual.DelayedCall(2f, () => _signalBus.Fire(new GameStateChangeSignal(GameState.Tutorial)));
        }

        public void Exit() { }
        public void Update() { }
    }
}