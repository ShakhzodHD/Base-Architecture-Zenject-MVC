using UnityEngine;
using Zenject;

namespace Core
{
    public class TutorialStateHandler : IGameStateHandler
    {
        private readonly SignalBus _signalBus;

        public TutorialStateHandler(SignalBus signalBus)
        {
            _signalBus = signalBus;
        }

        public void Enter()
        {
            Debug.Log("Tutorial Started");

            _signalBus.Fire(new GameEventSignal(GameEvent.TutorialCompleted));
        }

        public void Exit()
        {
            Debug.Log("Tutorial Completed");
        }

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _signalBus.Fire(new GameEventSignal(GameEvent.TutorialCompleted));
            }
        }
    }
}