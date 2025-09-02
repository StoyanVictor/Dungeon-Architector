using CodeBase;
using CodeBase.EnemyHero;
using Zenject;

public class FabricInstaller : MonoInstaller
{
    public UnitFactory unitFactory;
    public UnitSpawner UnitSpawner;
    public EnemyHeroFabric heroFabric;
    public LevelSwitcher LevelSwitcher;
    public override void InstallBindings()
    {
        BindUnitFactory();
    }

    private void BindUnitFactory()
    {
        Container.Bind<UnitFactory>().FromInstance(unitFactory).AsSingle();
        Container.Bind<UnitSpawner>().FromInstance(UnitSpawner).AsSingle();
        Container.Bind<EnemyHeroFabric>().FromInstance(heroFabric).AsSingle();
        Container.Bind<LevelSwitcher>().FromInstance(LevelSwitcher).AsSingle();
    }
}