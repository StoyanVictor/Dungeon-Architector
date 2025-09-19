using CodeBase;
using CodeBase.UnitS.AI;
using UnityEngine;
public class HellTowerAttack : IAttackBehaviourStrategy
{
    public void Attack(UnitAiController aiController)
    {
        if (aiController.aiLogic.GetCurrentTarget() != null)
        {
            aiController.aiLogic.LookAtTarget();
            RaycastHit hit;
            Vector3 dir = (aiController.aiLogic.GetCurrentTarget().position - aiController.transform.position).normalized;
            
            if (Physics.Raycast(aiController.transform.position + Vector3.up * 0.75f,dir,out hit, 5f,1 << 8))
            {
                if (hit.transform.gameObject.TryGetComponent(out EnemyHeroHealth enemyHealth))
                {
                    aiController.visualPlayer.unitAnimationPlayer.PlayAttackAnimation();
                    enemyHealth.TakeDamage(1);
                }
            }
        }
    }
}