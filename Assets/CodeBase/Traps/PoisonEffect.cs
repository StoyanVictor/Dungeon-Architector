using System.Collections;
using UnityEngine;

public class PoisonEffect : MonoBehaviour
{
    private EnemyHeroHealth enemyHeroHealth;
    private void Init()
    {
        enemyHeroHealth = GetComponent<EnemyHeroHealth>();
    }

    public void StartPoison(int poisonDuration, int damage)
    {
        Init();
        StartCoroutine(PoisonTicking(poisonDuration, damage));
    }

    private void UsePoisonDamage(int dmg) => enemyHeroHealth.TakeDamage(dmg);

    private IEnumerator PoisonTicking(int timerDuration,int dmg)
    {
        while (timerDuration > 0)
        {
            UsePoisonDamage(dmg);
            yield return new WaitForSeconds(1f);
            timerDuration--;
        }
        Destroy(this);
    }
}