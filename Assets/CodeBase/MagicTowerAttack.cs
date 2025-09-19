using System;
using CodeBase;
using CodeBase.UnitS.AI;
using Cysharp.Threading.Tasks;
using UnityEngine;
public class MagicTowerAttack : IAttackBehaviourStrategy
{
    private bool isCanShoot = true;
    private float reloadDuration = 2;
    public void Attack(UnitAiController aiController)
    {
        if (aiController.aiLogic.GetCurrentTarget() != null)
        {
            aiController.aiLogic.LookAtTarget();
            RaycastHit hit;
            Vector3 dir = (aiController.aiLogic.GetCurrentTarget().position - aiController.transform.position).normalized;
            
            if (Physics.Raycast(aiController.transform.position + Vector3.up * 0.75f,dir,out hit, 5f,1 << 8))
            {
                if (hit.transform.gameObject.TryGetComponent(out EnemyHeroHealth enemyHealth) && isCanShoot)
                {
                    Shoot(aiController, dir,hit.transform.gameObject);
                }
            }
        }
    }

    private async void Shoot(UnitAiController aiController, Vector3 dir,GameObject obj)
    {
        isCanShoot = false;
        var projectile = aiController.aiLogic.projectilePool.GetProjectile();
        var rb = projectile.gameObject.GetComponent<Rigidbody>();
        var distance = Vector3.Distance(aiController.transform.position, obj.transform.position);
        rb.AddForce(dir * distance * 2,ForceMode.Impulse);
        await UniTask.WaitForSeconds(reloadDuration);
        isCanShoot = true;
    }
}