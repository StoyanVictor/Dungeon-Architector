using UnityEngine;
using Zenject;

namespace CodeBase.Installers
{
    public class SpawnerInstaller : MonoInstaller
    {
        public GameObject buildingSpawnerPrefab;
        public override void InstallBindings()
        {
            BindSpawner();
        }

        private void BindSpawner()
        {
            Container.Bind<BuildingSpawner>()
                .FromComponentInNewPrefab(buildingSpawnerPrefab)
                .AsSingle();

        }
    }
}