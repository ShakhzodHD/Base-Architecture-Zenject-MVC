namespace Core
{
    public interface IGameController
    {
        GameState CurrentState { get; }
        void Initialize();
        void ChangeState(GameState newState);
        void HandleGameEvent(GameEvent gameEvent);
    }
}