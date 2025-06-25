namespace Core
{
    public class GameStateChangedSignal
    {
        public GameState PreviousState { get; }
        public GameState NewState { get; }

        public GameStateChangedSignal(GameState previousState, GameState newState)
        {
            PreviousState = previousState;
            NewState = newState;
        }
    }
}