using System;
using System.Collections;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;

public class SlowEffect : MonoBehaviour, ITrapEffect
{
    private NavMeshAgent agent;
    private void Init()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    public void StartEffect(int poisonDuration,int value)
    {
        Init();
        SlowTicking(poisonDuration);
    }

    private void UseSlow() => agent.speed = 1;

    private async UniTask SlowTicking(int timerDuration)
    {
        while (timerDuration > 0)
        {
            UseSlow();
            await UniTask.Delay(TimeSpan.FromSeconds(1));
            timerDuration--;
        }

        agent.speed = 2;
        Destroy(this);
    }
}