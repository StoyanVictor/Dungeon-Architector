using Zenject;

public class FabricInstaller : MonoInstaller
{
    public UnitFactory unitFactory;
    public UnitSpawner UnitSpawner;
    public override void InstallBindings()
    {
        BindUnitFactory();
    }

    private void BindUnitFactory()
    {
        Container.Bind<UnitFactory>().FromInstance(unitFactory).AsSingle();
        Container.Bind<UnitSpawner>().FromInstance(UnitSpawner).AsSingle();
    }
}