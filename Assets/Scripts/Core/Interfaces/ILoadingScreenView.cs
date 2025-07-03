namespace Core
{
    public interface ILoadingScreenView : IUIView
    {
        void UpdateProgress(float progress);
    }
}