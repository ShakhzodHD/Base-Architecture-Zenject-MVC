namespace Core
{
    public class GameEventSignal
    {
        public GameEvent GameEvent { get; }

        public GameEventSignal(GameEvent gameEvent)
        {
            GameEvent = gameEvent;
        }
    }
}