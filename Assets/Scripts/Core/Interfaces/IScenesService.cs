using System;
using System.Threading.Tasks;

namespace ScenesService
{
    public interface IScenesService
    {
        event Action<string> OnSceneLoadStarted;
        event Action<string> OnSceneLoadCompleted;

        string CurrentSceneName { get; }
        bool IsLoading { get; }

        Task LoadSceneAsync(string sceneName);
        Task LoadLevelAsync(int levelIndex);
        Task ReloadCurrentSceneAsync();
        void LoadSceneImmediate(string sceneName);
    }
}