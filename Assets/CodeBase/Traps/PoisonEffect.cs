using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class PoisonEffect : MonoBehaviour,ITrapEffect
{
    private EnemyHeroHealth enemyHeroHealth;
    private void Init()
    {
        enemyHeroHealth = GetComponent<EnemyHeroHealth>();
    }

    public void StartEffect(int poisonDuration, int damage)
    {
        Init();
        PoisonTicking(poisonDuration, damage);
    }

    private void UsePoisonDamage(int dmg) => enemyHeroHealth.TakeDamage(dmg);

    private async UniTask PoisonTicking(int timerDuration,int dmg)
    {
        while (timerDuration > 0)
        {
            UsePoisonDamage(dmg);
            await UniTask.Delay(TimeSpan.FromSeconds(1));
            timerDuration--;
        }
        Destroy(this);
    }
}