namespace Core
{
    public interface IMainMenuView : IUIView
    {
        // Специфичные методы для MainMenu, если нужны
        void SetPlayerName(string name);
        void ShowLoadingState(bool isLoading);
    }
}