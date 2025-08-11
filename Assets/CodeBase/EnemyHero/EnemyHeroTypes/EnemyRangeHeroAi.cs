using CodeBase.EnemyHero;
using UnityEngine;

public class EnemyRangeHeroAi : EnemyHeroAiBase
{
    
    public override void Move()
    {
        if (!FindTarget())
        {
            agent.SetDestination(maintTarget.transform.position);
            animationPlayer.PlayWalkAnimation();
        }
        if (FindTarget() && !CheckForAttackRange())
        {
            animationPlayer.PlayWalkAnimation();
            agent.SetDestination(GetCurrentTarget().transform.position);
        }
        else
        {
            return;
        }
    }
    
    private void Update()
    {
        currentState.Excute();
    }
    
    public override void Attack()
    {
        if (CheckForAttackRange())
        {
            animationPlayer.PlayAttackAnimation();
        }
    }
}