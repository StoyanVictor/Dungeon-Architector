using Zenject;

namespace CodeBase.Installers
{
    public class BankInstaller : MonoInstaller
    {
        public Bank bankService;
        public override void InstallBindings()
        {
            BindUnitFactory();
        }

        private void BindUnitFactory()
        {
            Container.Bind<Bank>().FromInstance(bankService).AsSingle();
            
        }
    }
}