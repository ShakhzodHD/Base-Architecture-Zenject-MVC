using UnityEngine;
using Zenject;

namespace Core
{
    public class Bootstrap : MonoBehaviour
    {
        [Inject] private readonly IGameController _gameController;

        private void Start()
        {
            Debug.Log("Bootstrap Start");
            _gameController.Initialize();
        }

        private void Update()
        {
            Debug.Log("Current State: " + _gameController.CurrentState);
        }
    }
}