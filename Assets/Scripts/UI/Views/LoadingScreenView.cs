using Core;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UIManager
{
    public class LoadingScreenView : UIView, ILoadingScreenView
    {
        [SerializeField] private Slider progressBar;
        [SerializeField] private Text progressText;

        private float displayedProgress;

        [Inject]
        public void Construct(SignalBus signalBus)
        {
            signalBus.Subscribe<SceneLoadProgressSignal>(OnProgressUpdated);
        }

        private void OnProgressUpdated(SceneLoadProgressSignal signal)
        {
            UpdateProgress(signal.Progress);
        }

        protected override void OnShow()
        {
            Debug.Log("Loading Screen Show");

            UpdateProgress(0f);
        }

        protected override void OnHide()
        {
            Debug.Log("Loading Screen Hidden");
        }

        public void UpdateProgress(float progress)
        {
            float targetProgress = Mathf.Clamp01(progress / 0.9f);
            displayedProgress = Mathf.Lerp(displayedProgress, targetProgress, Time.deltaTime * 5f);
            progressBar.value = displayedProgress;
            if (progressText != null)
            {
                progressText.text = $"{(displayedProgress * 100):F0}%";
            }
        }
    }
}