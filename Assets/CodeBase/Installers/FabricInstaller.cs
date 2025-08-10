using CodeBase.EnemyHero;
using Zenject;

public class FabricInstaller : MonoInstaller
{
    public UnitFactory unitFactory;
    public UnitSpawner UnitSpawner;
    public EnemyHeroFabric heroFabric;
    public override void InstallBindings()
    {
        BindUnitFactory();
    }

    private void BindUnitFactory()
    {
        Container.Bind<UnitFactory>().FromInstance(unitFactory).AsSingle();
        Container.Bind<UnitSpawner>().FromInstance(UnitSpawner).AsSingle();
        Container.Bind<EnemyHeroFabric>().FromInstance(heroFabric).AsSingle();
    }
}