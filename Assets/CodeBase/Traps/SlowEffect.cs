using System.Collections;
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
        StartCoroutine(SlowTicking(poisonDuration));
    }

    private void UseSlow() => agent.speed = 1;

    private IEnumerator SlowTicking(int timerDuration)
    {
        while (timerDuration > 0)
        {
            UseSlow();
            yield return new WaitForSeconds(1f);
            timerDuration--;
        }

        agent.speed = 2;
        Destroy(this);
    }
}