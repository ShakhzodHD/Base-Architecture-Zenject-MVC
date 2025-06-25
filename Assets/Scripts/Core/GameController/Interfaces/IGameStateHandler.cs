namespace Core
{
    public interface IGameStateHandler
    {
        void Enter();
        void Exit();
        void Update();
    }
}