using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace CodeBase.EnemyHero
{
    public class EnemyHeroSpawner : MonoBehaviour
    {
        [SerializeField] private LevelSwitcher lvlSwitcher;
        [SerializeField] private Transform spawnPos;
        [SerializeField] private TimerShower _timerShower;
        [SerializeField] private int currentWave;
        public List<EnemyHeroData> enemiesAlive;
        private EnemyHeroFabric enemyFabric;

        
        [Inject]
        public void Construct(EnemyHeroFabric _enemyFabric)
        {
            enemyFabric = _enemyFabric;
        }

        private void OnEnable()
        {
            EventBus.Instance.OnEnemyDied += CheckIfWaveIsFinished;
        }

        private void CheckIfWaveIsFinished()
        {
            if (enemiesAlive.Count == 1)
            {
                enemiesAlive.RemoveAt(0);
                Debug.LogAssertion($"Im starting new wave");
                StartCoroutine(WaveTimer(_timerShower.GetTimerDuration()));
                Debug.LogAssertion($"Im starting new wave1");
            }
            else enemiesAlive.RemoveAt(0);
        }

        private IEnumerator WaveTimer(int s)
        {
            _timerShower.StartTimer();
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
        }

        private void Awake()
        {
            StartCoroutine(WaveTimer(_timerShower.GetTimerDuration()));
        }
        
    }
}