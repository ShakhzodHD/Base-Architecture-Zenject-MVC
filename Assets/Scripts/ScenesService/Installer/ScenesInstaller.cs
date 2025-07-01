using UnityEngine;
using Zenject;

namespace ScenesService
{
    public class ScenesInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Debug.Log("Scenes Installer");

            Container.Bind<IScenesService>().To<ScenesService>().AsSingle().Lazy();
        }
    }
}