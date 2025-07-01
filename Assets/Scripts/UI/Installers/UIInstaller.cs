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
        [SerializeField] private LoadingScreenView loadingScreenViewPrefab;

        public override void InstallBindings()
        {
            Debug.Log("UI Install");

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

            var loadingScreenView = Container.InstantiatePrefabForComponent<LoadingScreenView>(loadingScreenViewPrefab);
            Container.Bind<LoadingScreenView>().FromInstance(loadingScreenView);
            Container.Bind<IUIView>().FromInstance(loadingScreenView);
            views.Add(loadingScreenView);

            Container.Bind<List<IUIView>>().FromInstance(views);
        }
    }
}