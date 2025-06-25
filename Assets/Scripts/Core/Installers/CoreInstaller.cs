using UnityEngine;
using Zenject;

namespace Core
{
    public class CoreInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Debug.Log("Core Install");
        }
    }
}