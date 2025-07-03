namespace Core
{
    public class SceneLoadProgressSignal
    {
        public float Progress { get; }
        public SceneLoadProgressSignal(float progress) => Progress = progress;
    }
}