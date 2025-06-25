namespace Core
{
    public class GameStateChangeSignal
    {
        public GameState NewState { get; }

        public GameStateChangeSignal(GameState newState)
        {
            NewState = newState;
        }
    }
}