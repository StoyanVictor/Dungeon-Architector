using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace CodeBase.Installers
{
    public class SpawnerInstaller : MonoInstaller
    {
        public GameObject buildingSpawnerPrefab;
        public CellSpawner cellSpawner;
        public GameFieldGenerator gameFieldGenerator;
        private GameFieldBehaviourAdjuster gameFieldBehaviourAdjuster;
        public override void InstallBindings()
        {
            BindSpawner();
            Container.Bind<CellSpawner>().FromInstance(cellSpawner).AsSingle();
            Container.Bind<GameFieldGenerator>().FromInstance(gameFieldGenerator).AsSingle();
            Container.Bind<GameFieldBehaviourAdjuster>().FromInstance(new GameFieldBehaviourAdjuster()).AsSingle();
        }

        private void BindSpawner()
        {
            Container.Bind<BuildingSpawner>()
                .FromComponentInNewPrefab(buildingSpawnerPrefab)
                .AsSingle();

        }
    }
}