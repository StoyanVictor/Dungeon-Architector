using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace CodeBase.EnemyHero
{
    public class EnemyHeroSpawner : MonoBehaviour
    {
        [SerializeField] private LevelSwitcher lvlSwitcher;
        [SerializeField] private Transform spawnPos;
        [SerializeField] private TimerShower timerShower;
        [SerializeField] private int currentWave;
        [SerializeField] private FabricCreatingSfxPlayer sfxPlayer;
        public List<EnemyHeroData> enemiesAlive;
        private EnemyHeroFabric enemyFabric;
        private EventBus eventBus;

        [Inject]
        public void Construct(EnemyHeroFabric _enemyFabric,EventBus _eventBus)
        {
            enemyFabric = _enemyFabric;
            eventBus = _eventBus;
        }

        private void OnEnable()
        {
            eventBus.OnEnemyDied += CheckIfWaveIsFinished;
        }

        private void CheckIfWaveIsFinished()
        {
            if (enemiesAlive.Count == 1)
            {
                enemiesAlive.RemoveAt(0);
                WaveTimer();
            }
            else if (enemiesAlive.Count > 1)
                enemiesAlive.RemoveAt(0);
            else return;
        }

        private async void WaveTimer()
        {
            await timerShower.StartTimer();
            SpawnEnemy();
        }

        private void SpawnEnemy()
        {
            
            if (lvlSwitcher.GetLevels()[lvlSwitcher.GetCurrentLvlIndex()].LevelWaves.Count <= currentWave)
            {
                Debug.LogWarning($"<color=green>I win level:</color> {lvlSwitcher.GetCurrentLvlIndex()}");
                lvlSwitcher.SwitchLvl();
                currentWave = 0;
            }

            foreach (var enemyHeroes in lvlSwitcher.GetLevels()[lvlSwitcher.GetCurrentLvlIndex()].LevelWaves[currentWave].GetAllEnemies())
            {
                enemyFabric.Create(enemyHeroes.enemyHeroType,spawnPos);
                enemiesAlive.Add(enemyHeroes);
            }
            currentWave++;
            sfxPlayer.PlayCreateSFX();
        }

        private void Awake()
        {
            WaveTimer();
        }
        
    }
}