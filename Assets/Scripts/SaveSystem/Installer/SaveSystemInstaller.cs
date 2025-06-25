using Core;
using UnityEngine;
using Zenject;

namespace SaveSystem
{
    public class SaveSystemInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Debug.Log("Save System Install");

            Container.Bind<ISaveSystem>().To<SaveSystem>().AsSingle();
        }
    }
}