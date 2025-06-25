namespace Core
{
    public interface ISaveSystem
    {
        bool IsFirstLaunch();
        void SetFirstLaunchCompleted();
        void SaveProgress(int levelIndex);
        int GetLastCompletedLevel();
    }
}