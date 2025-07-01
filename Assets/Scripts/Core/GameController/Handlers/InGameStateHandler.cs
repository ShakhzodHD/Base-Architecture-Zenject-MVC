using UnityEngine;
using Zenject;

namespace Core
{
    public class InGameStateHandler : IGameStateHandler
    {
        private readonly SignalBus _signalBus;

        public InGameStateHandler(SignalBus signalBus)
        {
            _signalBus = signalBus;
        }

        public void Enter()
        {
            Debug.Log("Game Started");
            Time.timeScale = 1f;
        }

        public void Exit()
        {
            Debug.Log("Game Ended");
        }

        public void Update()
        {
            //if (Input.GetKeyDown(KeyCode.Escape))
            //{
            //    _signalBus.Fire(new GameEventSignal(GameEvent.ReturnToMenu));
            //}
        }
    }
}