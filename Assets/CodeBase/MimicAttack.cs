using CodeBase;
using CodeBase.UnitS.AI;
using DG.Tweening;
using UnityEngine;

public class MimicAttack : IAttackBehaviourStrategy
{
    private bool canCast;
    public void Attack(UnitAiController aiController)
    {
        aiController.visualPlayer.unitAnimationPlayer.PlayAttackAnimation();
        if (aiController.aiLogic.CheckForAttackRange() && !canCast)
        {
            aiController.visualPlayer.unitAnimationPlayer.PlayIdleAnimation();
            Collider[] enemies;
            enemies = Physics.OverlapSphere(aiController.gameObject.transform.position, 5);
            foreach (var enemy in enemies)
            {
                if (enemy.TryGetComponent(out EnemyHeroHealth enemyHealth) && !canCast)
                {
                    GameObject obj = enemyHealth.gameObject;
                    canCast = true;
                   var a = obj.transform.DOScale(Vector3.zero, 0.1f);
                   a.onComplete = () => HideObject(aiController, obj);
                   DOTween.Complete(a);
                }
            }
        }
    }

    private void HideObject(UnitAiController aiController, GameObject obj)
    {
        obj.SetActive(false);
        aiController.aiLogic.unitHealth.objectFromUnitInside = obj;
        aiController.attackStrategy = new NoAttack();
    }
}