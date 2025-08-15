using System;
using CodeBase.TweenServices;
using UnityEngine;
using Zenject;

namespace CodeBase.EnemyHero
{
    public class EnemyHeroFabric : MonoBehaviour
    {
        private DiContainer _diContainer;
        private GameObject melee;
        private GameObject range;
        private GameObject dogMelee;
        private SpawnTweenService spawnTweenService;

        
        [Inject]
        public void Construct(DiContainer diContainer)
        {
            _diContainer = diContainer;
        }

        private void Awake()
        {
            Load();
            spawnTweenService = new SpawnTweenService();
        }

        private void Load()
        {
            melee = Resources.Load<GameObject>("Enemy/MeleeHero");
            range = Resources.Load<GameObject>("Enemy/RangeHero");
            dogMelee = Resources.Load<GameObject>("Enemy/DogMeleeHero");
        }

        public void  Create(EnemyHeroType enemyHeroType,Transform pos)
        {
            switch (enemyHeroType)
            {
                case EnemyHeroType.Melee:
                    Debug.LogWarning(_diContainer);
                var _melee = _diContainer.InstantiatePrefab(melee,pos.position,Quaternion.identity,null);
                    spawnTweenService.SpawnScaleTween(_melee.transform.localScale,_melee,0.4f);
                break;
                case EnemyHeroType.Range:
                var _range = _diContainer.InstantiatePrefab(range,pos.position,Quaternion.identity,null);
                spawnTweenService.SpawnScaleTween(_range.transform.localScale,_range,0.4f);
                break;
                case EnemyHeroType.Tank:
                    var _tank = _diContainer.InstantiatePrefab(dogMelee,pos.position,Quaternion.identity,null);
                    spawnTweenService.SpawnScaleTween(_tank.transform.localScale,_tank,0.4f);
                break;
            }
        }
    }
}