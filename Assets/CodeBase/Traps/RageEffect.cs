using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;

public class RageEffect : MonoBehaviour, ITrapEffect
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

    private void UseRage() => agent.speed = 1;

    private async UniTask SlowTicking(int timerDuration)
    {
        while (timerDuration > 0)
        {
            UseRage();
            await UniTask.Delay(TimeSpan.FromSeconds(1));
            timerDuration--;
        }

        agent.speed = 2;
        Destroy(this);
    }
}