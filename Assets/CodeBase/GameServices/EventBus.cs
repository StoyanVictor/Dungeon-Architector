using System;
using UnityEngine;

public class EventBus : MonoBehaviour
{
    public event Action OnEnemyDied;
    public event Action<int> OnTimerTick;
    public void EnemyDies() => OnEnemyDied?.Invoke();
}