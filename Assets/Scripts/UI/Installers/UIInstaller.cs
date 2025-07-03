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

            Container.BindInterfacesAndSelfTo<UIManager>().AsSingle();

            InstallUIViews();
        }

        private void InstallUIViews()
        {
            var mainMenuView = Container.InstantiatePrefabForComponent<MainMenuView>(mainMenuViewPrefab);
            Container.Bind<MainMenuView>().FromInstance(mainMenuView);
            Container.BindInterfacesTo<MainMenuView>().FromInstance(mainMenuView);

            var loadingScreenView = Container.InstantiatePrefabForComponent<LoadingScreenView>(loadingScreenViewPrefab);
            Container.Bind<LoadingScreenView>().FromInstance(loadingScreenView);
            Container.BindInterfacesTo<LoadingScreenView>().FromInstance(loadingScreenView);
        }
    }
}