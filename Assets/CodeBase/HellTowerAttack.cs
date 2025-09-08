using CodeBase;
using CodeBase.UnitS.AI;
using UnityEngine;
public class HellTowerAttack : IAttackBehaviourStrategy
{
    public void Attack(UnitAi ai)
    {
        if (ai.GetCurrentTarget() != null)
        {
            Debug.Log($"Damn im trying to attack!{ai.GetCurrentTarget()}");
            Debug.DrawLine(ai.transform.position +  Vector3.up* 0.75f, ai.GetCurrentTarget().position +  Vector3.up* 0.75f,Color.blue,5f);
            ai.LookAtTarget();
            RaycastHit hit;
            Vector3 dir = (ai.GetCurrentTarget().position - ai.transform.position).normalized;
            
            if (Physics.Raycast(ai.transform.position + Vector3.up * 0.75f,dir,out hit, 5f,1 << 8))
            {
                Debug.Log($"We throwing our ray {hit.transform.name}");
                if (hit.transform.gameObject.TryGetComponent(out EnemyHeroHealth enemyHealth))
                {
                    ai.unitAnimationPlayer.PlayAttackAnimation();
                    enemyHealth.TakeDamage(1);
                    Debug.Log("We found enemy with ray!");
                }
            }
            
        }
    }
}