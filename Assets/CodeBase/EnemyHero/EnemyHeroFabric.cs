using System;
using UnityEngine;
using Zenject;

namespace CodeBase.EnemyHero
{
    public class EnemyHeroFabric : MonoBehaviour
    {
        private DiContainer _diContainer;
        private GameObject melee;
        private GameObject range;
        
        [Inject]
        public void Construct(DiContainer diContainer)
        {
            _diContainer = diContainer;
        }

        private void Awake()
        {
            Load();
        }

        private void Load()
        {
            melee = Resources.Load<GameObject>("Enemy/MeleeHero");
            range = Resources.Load<GameObject>("Enemy/RangeHero");
        }

        public void  Create(EnemyHeroType enemyHeroType,Transform pos)
        {
            switch (enemyHeroType)
            {
                case EnemyHeroType.Melee:
                    Debug.LogWarning(_diContainer);
                _diContainer.InstantiatePrefab(melee,pos.position,Quaternion.identity,null);
                break;
                case EnemyHeroType.Range:
                _diContainer.InstantiatePrefab(range,pos.position,Quaternion.identity,null);
                break;
            }
        }
    }
}