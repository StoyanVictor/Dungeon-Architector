using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace CodeBase.EnemyHero
{
    public class EnemyHeroSpawner : MonoBehaviour
    {
        [SerializeField] private List<EnemyHeroData> _enemyHeroDatas;
        [SerializeField] private Transform spawnPos;
        private EnemyHeroFabric enemyFabric;

        
        [Inject]
        public void Construct(EnemyHeroFabric _enemyFabric)
        {
            enemyFabric = _enemyFabric;
        }

        private void SpawnEnemy()
        {
            foreach (var enemyHeroes in _enemyHeroDatas)
            {
                enemyFabric.Create(enemyHeroes.enemyHeroType,spawnPos);
            }
        }

        private void Start()
        {
            SpawnEnemy();
        }
        
    }
}