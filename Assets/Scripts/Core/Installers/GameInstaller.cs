using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Core
{
    public class GameInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Debug.Log("Game Install");

            SignalBusInstaller.Install(Container);

            Container.Bind<IGameController>().To<GameController>().AsSingle();

            Container.Bind<IGameStateHandler>().WithId(GameState.FirstLaunch)
                     .To<FirstLaunchStateHandler>().AsSingle();
            Container.Bind<IGameStateHandler>().WithId(GameState.Tutorial)
                     .To<TutorialStateHandler>().AsSingle();
            Container.Bind<IGameStateHandler>().WithId(GameState.MainMenu)
                     .To<MainMenuStateHandler>().AsSingle();
            Container.Bind<IGameStateHandler>().WithId(GameState.LevelSelect)
                     .To<LevelSelectStateHandler>().AsSingle();
            Container.Bind<IGameStateHandler>().WithId(GameState.InGame)
                     .To<InGameStateHandler>().AsSingle();
            Container.Bind<IGameStateHandler>().WithId(GameState.GameOver)
                     .To<GameOverStateHandler>().AsSingle();

            Container.Bind<Dictionary<GameState, IGameStateHandler>>()
                     .FromMethod(CreateStateHandlers).AsSingle();

            Container.DeclareSignal<GameEventSignal>();
            Container.DeclareSignal<GameStateChangeSignal>();
            Container.DeclareSignal<GameStateChangedSignal>();
        }

        private Dictionary<GameState, IGameStateHandler> CreateStateHandlers(InjectContext context)
        {
            var handlers = new Dictionary<GameState, IGameStateHandler>();

            handlers[GameState.FirstLaunch] = context.Container.ResolveId<IGameStateHandler>(GameState.FirstLaunch);
            handlers[GameState.Tutorial] = context.Container.ResolveId<IGameStateHandler>(GameState.Tutorial);
            handlers[GameState.MainMenu] = context.Container.ResolveId<IGameStateHandler>(GameState.MainMenu);
            handlers[GameState.LevelSelect] = context.Container.ResolveId<IGameStateHandler>(GameState.LevelSelect);
            handlers[GameState.InGame] = context.Container.ResolveId<IGameStateHandler>(GameState.InGame);
            handlers[GameState.GameOver] = context.Container.ResolveId<IGameStateHandler>(GameState.GameOver);

            return handlers;
        }
    }
}