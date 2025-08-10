using CodeBase.EnemyHero;
using UnityEngine;

public class EnemyHeroAttackState : IEnemyHeroState
{
    private EnemyHeroAiBase enemyAi;
        
    public EnemyHeroAttackState(EnemyHeroAiBase _enemyAi)
    {
        enemyAi = _enemyAi;
    }

    public void EnterState()
    {
        Debug.LogWarning("Im start attacking!");
    }

    public void Excute()
    {
        if (enemyAi.CheckForAttackRange())
        {
            enemyAi.Attack();
        }
        else if(enemyAi.FindTarget() && !enemyAi.CheckForAttackRange())
            enemyAi.SwitchState(new EnemyHeroChaseState(enemyAi));
                
    }

    public void ExitState()
    {
        
    }
}