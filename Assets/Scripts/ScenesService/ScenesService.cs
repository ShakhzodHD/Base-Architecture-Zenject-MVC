using Core;
using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace ScenesService
{
    public class ScenesService : IScenesService, IInitializable, IDisposable
    {
        public event Action<string> OnSceneLoadStarted;
        public event Action<string> OnSceneLoadCompleted;

        public string CurrentSceneName { get; private set; }
        public bool IsLoading { get; private set; }

        void IInitializable.Initialize()
        {
            CurrentSceneName = SceneManager.GetActiveScene().name;
            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        public void Dispose()
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }

        public async Task LoadSceneAsync(string sceneName)
        {
            if (IsLoading)
            {
                Debug.LogWarning($"Scene loading in progress. Cannot load {sceneName}");
                return;
            }

            IsLoading = true;
            OnSceneLoadStarted?.Invoke(sceneName);

            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);

            while (!asyncLoad.isDone)
            {
                await Task.Yield();
            }

            CurrentSceneName = sceneName;
            IsLoading = false;
            OnSceneLoadCompleted?.Invoke(sceneName);
        }

        public async Task LoadLevelAsync(int levelIndex)
        {
            string levelName = $"{Constants.NEW_SCENE_NAME}{levelIndex:D2}";
            await LoadSceneAsync(levelName);
        }

        public async Task ReloadCurrentSceneAsync()
        {
            await LoadSceneAsync(CurrentSceneName);
        }

        public void LoadSceneImmediate(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }

        private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            CurrentSceneName = scene.name;
        }
    }
}