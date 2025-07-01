using UnityEngine;
using Zenject;

namespace Core
{
    public class Bootstrap : MonoBehaviour
    {
        [Inject] private readonly IGameController _gameController;
        private static Bootstrap _instance;
        private void Awake()
        {
            if (_instance == null)
            {
                _instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void Start()
        {
            Debug.Log("Bootstrap Start");
            _gameController.Initialize();
        }

        private void Update()
        {
            //Debug.Log("Current State: " + _gameController.CurrentState);
        }
    }
}