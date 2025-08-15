using CodeBase.EnemyHero;
using UnityEngine;

public class EnemyMeleeHeroAi : EnemyHeroAiBase
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
            LookAtTarget();
        }
    }

    private void LookAtTarget()
    {
        if (currentTarget != null)
        {
            Vector3 lookPos = GetCurrentTarget().position - transform.position;
            lookPos.y = 0;
            transform.rotation = Quaternion.LookRotation(lookPos);
        }

    }
}