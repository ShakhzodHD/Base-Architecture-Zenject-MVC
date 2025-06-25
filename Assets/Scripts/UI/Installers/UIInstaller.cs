using Core;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace UIManager
{
    public class UIInstaller : MonoInstaller
    {
        [Header("UI Prefabs")]
        [SerializeField] private MainMenuView mainMenuViewPrefab;
        //[SerializeField] private LevelSelectView levelSelectViewPrefab;
        // ... другие UI префабы

        public override void InstallBindings()
        {
            Container.Bind<IUIManager>().To<UIManager>().AsSingle();

            InstallUIViews();
        }

        private void InstallUIViews()
        {
            var views = new List<IUIView>();

            var mainMenuView = Container.InstantiatePrefabForComponent<MainMenuView>(mainMenuViewPrefab);
            Container.Bind<MainMenuView>().FromInstance(mainMenuView);
            Container.Bind<IMainMenuView>().FromInstance(mainMenuView);
            views.Add(mainMenuView);

            //// Level Select View
            //var levelSelectView = Container.InstantiatePrefabForComponent<LevelSelectView>(levelSelectViewPrefab);
            //Container.Bind<LevelSelectView>().FromInstance(levelSelectView);
            //views.Add(levelSelectView);

            Container.Bind<List<IUIView>>().FromInstance(views);
        }
    }
}