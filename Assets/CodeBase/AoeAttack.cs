using System;
using CodeBase;
using CodeBase.UnitS.AI;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class AoeAttack : IAttackBehaviourStrategy
{
    private bool canCast;
    public void Attack(UnitAi ai)
    {
        if (!canCast)
        {
            Collider[] enemies;
            enemies = Physics.OverlapSphere(ai.gameObject.transform.position, 5,1 << 8);
            if (enemies.Length > 0)
            {
                foreach (var enemy in enemies)
                {
                    if (enemy.TryGetComponent(out EnemyHeroHealth enemyHealth))
                    {
                        enemyHealth.TakeDamage(10);
                    }
                }
                canCast = true;
                AoeAttackTimer(3);
            }
        }
    }
    public async void AoeAttackTimer(int t)
    {
        Debug.Log($"Wait cast timer!");
        await UniTask.Delay(TimeSpan.FromSeconds(t));
        canCast = false;
    }
}