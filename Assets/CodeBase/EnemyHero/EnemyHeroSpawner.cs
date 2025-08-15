using System.Collections;
using System.Collections.Generic;
using CodeBase.TweenServices;
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
                Debug.LogAssertion($"Im starting new wave");
                StartCoroutine(WaveTimer(timerShower.GetTimerDuration()));
                Debug.LogAssertion($"Im starting new wave1");
            }
            else enemiesAlive.RemoveAt(0);
        }

        private IEnumerator WaveTimer(int s)
        {
            timerShower.StartTimer();
            yield return new WaitForSeconds(s);
            SpawnEnemy();
        }

        private void SpawnEnemy()
        {
            
            if (lvlSwitcher.GetLevels()[lvlSwitcher.GetCurrentLvlIndex()].LevelWaves.Count <= currentWave)
            {
                Debug.LogWarning($"I win level: {lvlSwitcher.GetCurrentLvlIndex()}");
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
            StartCoroutine(WaveTimer(timerShower.GetTimerDuration()));
        }
        
    }
}