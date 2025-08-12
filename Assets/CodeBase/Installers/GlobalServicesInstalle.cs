using UnityEngine;
using Zenject;

namespace CodeBase.Installers
{
    public class GlobalServicesInstalle : MonoInstaller
    {
        [SerializeField] private EventBus eventBus;
        
        public override void InstallBindings()
        {
            BindUnitFactory();
        }

        private void BindUnitFactory()
        {
            Container.Bind<EventBus>().FromInstance(eventBus).AsSingle();
        }

    }
}