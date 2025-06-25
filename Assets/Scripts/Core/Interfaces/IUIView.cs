namespace Core
{
    public interface IUIView
    {
        void Show();
        void Hide();
        bool IsVisible { get; }
    }
}