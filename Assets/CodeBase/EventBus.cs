using System;
using UnityEngine;

public class EventBus : MonoBehaviour
{
    public static EventBus Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public event Action OnEnemyDied;
    public event Action<int> OnTimerTick;

    public void EnemyDies() => OnEnemyDied?.Invoke();
}