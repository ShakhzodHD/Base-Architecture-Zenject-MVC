namespace Core
{
    public interface IMainMenuView : IUIView
    {
        // ����������� ������ ��� MainMenu, ���� �����
        void SetPlayerName(string name);
        void ShowLoadingState(bool isLoading);
    }
}