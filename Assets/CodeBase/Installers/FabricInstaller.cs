using CodeBase;
using CodeBase.EnemyHero;
using UnityEngine.Serialization;
using Zenject;

public class FabricInstaller : MonoInstaller
{
    [FormerlySerializedAs("unitFactory")] public UnitFactoryTest unitFactoryTest;
    public UnitSpawner UnitSpawner;
    public EnemyHeroFabric heroFabric;
    public LevelSwitcher LevelSwitcher;
    public override void InstallBindings()
    {
        BindUnitFactory();
    }

    private void BindUnitFactory()
    {
        Container.Bind<UnitFactoryTest>().FromInstance(unitFactoryTest).AsSingle();
        Container.Bind<UnitSpawner>().FromInstance(UnitSpawner).AsSingle();
        Container.Bind<EnemyHeroFabric>().FromInstance(heroFabric).AsSingle();
        Container.Bind<LevelSwitcher>().FromInstance(LevelSwitcher).AsSingle();
    }
}