namespace Core
{
    public interface IUIManager
    {
        void ShowView<T>() where T : class, IUIView;
        void HideView<T>() where T : class, IUIView;
        void HideAllViews();
        T GetView<T>() where T : class, IUIView;
    }
}