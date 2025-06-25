using Core;
using UnityEngine;

namespace SaveSystem
{
    public class SaveSystem : ISaveSystem
    {
        private const string FIRST_LAUNCH_KEY = "FirstLaunch";
        private const string LEVEL_PROGRESS_KEY = "LevelProgress";

        public bool IsFirstLaunch()
        {
            return !PlayerPrefs.HasKey(FIRST_LAUNCH_KEY);
        }

        public void SetFirstLaunchCompleted()
        {
            PlayerPrefs.SetInt(FIRST_LAUNCH_KEY, 1);
            PlayerPrefs.Save();
        }

        public void SaveProgress(int levelIndex)
        {
            PlayerPrefs.SetInt(LEVEL_PROGRESS_KEY, levelIndex);
            PlayerPrefs.Save();
        }

        public int GetLastCompletedLevel()
        {
            return PlayerPrefs.GetInt(LEVEL_PROGRESS_KEY, 0);
        }
    }
}